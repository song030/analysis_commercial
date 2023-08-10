# -----------------------------------------------------------
# 파이썬으로 카카오맵 API를 활용하여 지도 HTML을 저장하는 파이썬 파일입니다.
# 작성자 : 송민정
# 작성일자 : 2023-08-08
# 명령어 예시 :
#       ex) kakao_map = KakaoMap() : 객체 생성
#       ex) kakao_map.set_map_info(latitude, longitude, 3) : 지도 정보 입력 (중심좌표, 확대 레벨)
#       ex) kakao_map.set_control_view(True) : 유저 컨트롤 출력 여부 설정
#       ex) kakao_map.set_mouse_over_event(True) : 마우스오버 이벤트 사용 여부 설정
#       ex) kakao_map.set_map_click_event(True) : 지도 클릭시 클릭한 위치로 마커 이동 이벤트 사용 여부 설정
#       ex) kakao_map.create_main_marker(True) : 메인 마커 생성 → 지도 중심 기준으로 생성됨
#       ex) kakao_map.get_add_marker(marker) : 마커 추가 생성
#          → 인자값 자료형 list[dict] : [{"title":"장소명", "LatLng":(36.9824163015563, 126.92003340131)}]
#       ex) kakao_map.save_map(file_path) : html 파일로 저장
# 예상 리턴은 관련 함수를 검색바랍니다.
# -----------------------------------------------------------

HOST = "song030s.dothome.co.kr"


class KakaoMap:
    def __init__(self):
        # --- option
        self.control = False  # 지도 컨트롤러 출력 여부
        self.map_click = False  # 지도 클릭시 마커 생성 여부
        self.mouse_over = False  # 마커에 마우스 오버 시 인포 출력 여부
        self.main_marker = False  # 지도 중심 마커 생성 여부
        self.marker_custom = False  # 마커 모양 파리바게트 이미지 출력 여부

        # --- info
        # {"lat": lat, "lng": lng, "title": title, "content": content, "level": level}
        self.map_info = {}  # 지도 중심 장소 정보, 지도 확대 정보

        # [{"title": "현화중학교", "LatLng": (36.9824163015563, 126.92003340131), "content": "중학교 정보입니다."}]
        self.marker_list = list()  # 지도 중심을 제외한 장소에 추가할 커스텀 마커 정보

    # html text 생성
    def create_html(self) -> str:
        html_text = f"""
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title>지도 생성하기</title>

        <style>
            html, body {{width:100%;height:100%;margin:0;padding:0;}}
            .map_wrap {{position:relative;overflow:hidden;width:100%;height:100%;}}
            {self.get_control_style() if self.control else ""}
        </style>
    </head>

    <body>
    <div class="map_wrap">
        <div id="map" style="width:100%;height:100%;position:relative;overflow:hidden;"></div>
        {self.get_control_div() if self.control else ""}
        <div id="clickLatlng">{self.map_info["lat"]} {self.map_info["lng"]}</div>
    </div>

    <script type="text/javascript" src="//dapi.kakao.com/v2/maps/sdk.js?appkey=36e6f8ef91e206312c99c8be04e55526"></script>
    <script>
        {self.get_control_func() if self.control else ""}
        {self.get_mouse_over_func() if self.mouse_over else ""}

        // 지도 생성
        var mapContainer = document.getElementById('map'),
        mapOption = {{
            center: new kakao.maps.LatLng({self.map_info["lat"]}, {self.map_info["lng"]}),
            level: {self.map_info["level"]}
        }};
        var map = new kakao.maps.Map(mapContainer, mapOption);

        // 파리바케뜨 마커 이미지
        var imageSrc = "http://{HOST}/Images/_markerStar.png"; 
        var imageSize = new kakao.maps.Size(55, 62);
        var markerImage = new kakao.maps.MarkerImage(imageSrc, imageSize);

        {self.get_map_click_func()}
        {self.get_main_marker()}
        {self.get_custom_marker()}

    </script>
    </body>
</html>"""

        return html_text

    def save_map(self, file_path: str):
        with open(file_path, 'w', encoding='UTF-8') as html_file:
            html_file.write(self.create_html())

    # ------------------------------ 지도 정보 설정 함수 ------------------------------

    # 지도 생성
    def set_map_info(self, lat, lng, level=3, title="", content=""):
        self.map_info = {"lat": lat, "lng": lng, "title": title, "content": content, "level": level}

    # 마커 생성
    def create_custom_marker(self, positions: list):
        # [{"title": "현화중학교", "LatLng": (36.9824163015563, 126.92003340131), "content": "중학교 정보입니다."}]
        self.marker_list = positions

    # --------------------------------------------------------------------------------

    # ------------------------------ 옵션 설정 함수 ------------------------------

    def create_main_marker(self):
        self.main_marker = True

    def set_control_view(self, control: bool):
        self.control = control

    def set_map_click_event(self, click: bool):
        self.map_click = click

    def set_mouse_over_event(self, over: bool):
        self.mouse_over = over

    def set_marker_custom(self, custom: bool):
        self.marker_custom = custom

    # --------------------------------------------------------------------------------

    # ------------------------------ html text 함수 ------------------------------

    # 지도 컨트롤 버튼 스타일
    @staticmethod
    def get_control_style():
        text = """// 지도 style
                    .radius_border{border:1px solid #919191;border-radius:5px;}
                    .custom_typecontrol {position:absolute;top:10px;right:10px;overflow:hidden;width:130px;height:30px;margin:0;padding:0;z-index:1;font-size:12px;font-family:'Malgun Gothic', '맑은 고딕', sans-serif;}
                    .custom_typecontrol span {display:block;width:65px;height:30px;float:left;text-align:center;line-height:30px;cursor:pointer;}
                    .custom_typecontrol .btn {background:#fff;background:linear-gradient(#fff,  #e6e6e6);}
                    .custom_typecontrol .btn:hover {background:#f5f5f5;background:linear-gradient(#f5f5f5,#e3e3e3);}
                    .custom_typecontrol .btn:active {background:#e6e6e6;background:linear-gradient(#e6e6e6, #fff);}
                    .custom_typecontrol .selected_btn {color:#fff;background:#425470;background:linear-gradient(#425470, #5b6d8a);}
                    .custom_typecontrol .selected_btn:hover {color:#fff;}
                    .custom_zoomcontrol {position:absolute;top:50px;right:10px;width:36px;height:80px;overflow:hidden;z-index:1;background-color:#f5f5f5;}
                    .custom_zoomcontrol span {display:block;width:36px;height:40px;text-align:center;cursor:pointer;}
                    .custom_zoomcontrol span img {width:15px;height:15px;padding:12px 0;border:none;}
                    .custom_zoomcontrol span:first-child{border-bottom:1px solid #bfbfbf;}
                        """
        return text

    # 지도 컨트롤 버튼 div
    @staticmethod
    def get_control_div():
        text = """<!-- 지도 컨트롤 div  -->
                        <div class="custom_typecontrol radius_border">
                    <span id="btnRoadmap" class="selected_btn" onclick="setMapType('roadmap')">지도</span>
                    <span id="btnSkyview" class="btn" onclick="setMapType('skyview')">스카이뷰</span>
                </div>

                <div class="custom_zoomcontrol radius_border"> 
                    <span onclick="zoomIn()"><img src="https://t1.daumcdn.net/localimg/localimages/07/mapapidoc/ico_plus.png" alt="확대"></span>  
                    <span onclick="zoomOut()"><img src="https://t1.daumcdn.net/localimg/localimages/07/mapapidoc/ico_minus.png" alt="축소"></span>
                </div>
                        """
        return text

    # 지도 컨트롤 버튼 클릭 이벤트 함수
    @staticmethod
    def get_control_func():
        text = f"""
                // 지도 컨트롤 함수
                function setMapType(maptype){{
                    var roadmapControl = document.getElementById('btnRoadmap');
                    var skyviewControl = document.getElementById('btnSkyview'); 
                    if (maptype === 'roadmap') {{
                        map.setMapTypeId(kakao.maps.MapTypeId.ROADMAP);    
                        roadmapControl.className = 'selected_btn';
                        skyviewControl.className = 'btn';
                    }} else {{
                        map.setMapTypeId(kakao.maps.MapTypeId.HYBRID);    
                        skyviewControl.className = 'selected_btn';
                        roadmapControl.className = 'btn';
                    }}
                }}

                function zoomIn() {{
                    map.setLevel(map.getLevel() - 1);
                }}

                function zoomOut() {{
                    map.setLevel(map.getLevel() + 1);
                }}
                """
        return text

    # 마우스 오버 이벤트 함수
    @staticmethod
    def get_mouse_over_func():
        text = f"""
        function makeOverListener(map, marker, infowindow) {{
            return function() {{
                infowindow.open(map, marker);
            }};
        }}

        function makeOutListener(infowindow) {{
            return function() {{
                infowindow.close();
            }};
        }}
        """

        return text

    # 맵 클릭 이벤트 함수
    def get_map_click_func(self):
        if self.map_click:
            text = """// 맵 클릭 이벤트
        kakao.maps.event.addListener(map, 'click', function(mouseEvent) {
            var latlng = mouseEvent.latLng; 
            marker.setPosition(latlng);

            var message = latlng.getLat() +  ' ' + latlng.getLng();
            var resultDiv = document.getElementById('clickLatlng'); 
            resultDiv.innerHTML = message;
        });"""
        else:
            text = ""

        return text

    # 메인 마커
    def get_main_marker(self):
        # --- 타이틀 확인
        title = ""
        if self.map_info['title'] != "":
            title = "title: '" + self.map_info['title'] + "', "

        # --- 인포 확인
        content = ""
        if self.map_info['content'] != "":
            content = f"""
                    // 마커의 인포 생성
                    var infowindow = new kakao.maps.InfoWindow({{
                        content: '<div style = "padding:5px;">{self.map_info['content']}</div>'
                        }});
                    """

            # 마우스 오버 이벤트 여부 확인
            if self.mouse_over:
                content += """
                        kakao.maps.event.addListener(marker, 'mouseover', makeOverListener(map, marker, infowindow));
                        kakao.maps.event.addListener(marker, 'mouseout', makeOutListener(infowindow));
                                    """
            else:
                content += f"""
                        // 인포를 마커 위에 출력하기
                        infowindow.open(map, marker);
                    """

        text = f"""
                    // 메인 마커 생성
                    var markerPosition = new kakao.maps.LatLng({self.map_info['lat']}, {self.map_info['lng']});
                    var marker = new kakao.maps.Marker({{
                        {title}
                        position: markerPosition
                        {", image: markerImage" if self.marker_custom else ""}
                    }});
                    marker.setMap(map);
                    {content}
                    """
        return text

    # 추가 마커
    def get_add_marker(self):
        if len(self.marker_list) == 0:
            return ""

        else:
            text = """
                // 커스텀 마커 생성
                var positions = ["""

            for idx, position in enumerate(self.marker_list):
                text += f"""
                    {{
                        title: '{position['title']}',
                        latlng: new kakao.maps.LatLng({position['LatLng'][0]}, {position['LatLng'][1]})
                    }}
                    """
                if idx < len(self.marker_list) - 1:
                    text += ",\n"

            text += f"""
                ];
                var imageSrc = "http://{HOST}/Images/_markerStar.png"; 

                for (var i=0; i<positions.length; i++){{
                    var imageSize = new kakao.maps.Size(55, 62);
                    var markerImage = new kakao.maps.MarkerImage(imageSrc, imageSize);
                    var marker = new kakao.maps.Marker({{
                        map: map,
                        position: positions[i].latlng,
                        title: positions[i].title,
                        image: markerImage
                    }});
                }}"""

        return text

    # --------------------------------------------------------------------------------
