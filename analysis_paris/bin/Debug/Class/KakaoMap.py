# -----------------------------------------------------------
# 파이썬으로 카카오맵 API를 활용하여 지도 HTML을 저장하는 파이썬 파일입니다.
# 작성자 : 송민정
# 작성일자 : 2023-08-08
# 명령어 예시 :
#       ex) kakao_map = KakaoMap() : 객체 생성
#       ex) kakao_map.create_map(latitude, longitude, 3) : 지도 생성 (중심좌표, 확대 레벨)
#       ex) kakao_map.set_control(True) : 유저 컨트롤 추가 여부 설정
#       ex) kakao_map.set_mouse_over(True) : 마우스오버 이벤트 사용 여부 설정
#       ex) kakao_map.set_map_click(True) : 지도 클릭시 클릭한 위치로 마커 이동 이벤트 사용 여부 설정
#       ex) kakao_map.create_main_marker() : 메인 마커 생성 → 지도 중심 기준으로 생성됨
#       ex) kakao_map.create_custom_marker(marker) : 커스텀 마커 생성
#          → 인자값 자료형 list[dict] : [{"title":"장소명", "LatLng":(36.9824163015563, 126.92003340131)}]
#       ex) kakao_map.save_map(file_path) : html 파일로 저장
# 예상 리턴은 관련 함수를 검색바랍니다.
# -----------------------------------------------------------

HOST = "song030s.dothome.co.kr"


class KakaoMap:
    # [ {"header": "info", "index":{"title":"", "lat":123, "lng":123}} ]
    custom = list()

    # option
    control = False
    map_click = False
    mouse_over = False

    main_marker = False
    map_center = {}

    # html 필수 요소 추가후 text생성 하여 반환
    def html(self) -> str:
        custom = self.custom.copy()
        custom.insert(0, {"header": "start", 'index': ''})
        custom.append({"header": "end", 'index': ''})

        return self.create_html(custom)

    # html text 생성
    def create_html(self, custom: list) -> str:
        html_text = ""

        for script in custom:
            # print(script)
            _type = script['header']
            _data = script['index']

            if _type == "start":
                control_style = """// 지도 style
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

                control_div = """<!-- 지도 컨트롤 div  -->
                <div class="custom_typecontrol radius_border">
            <span id="btnRoadmap" class="selected_btn" onclick="setMapType('roadmap')">지도</span>
            <span id="btnSkyview" class="btn" onclick="setMapType('skyview')">스카이뷰</span>
        </div>

        <div class="custom_zoomcontrol radius_border"> 
            <span onclick="zoomIn()"><img src="https://t1.daumcdn.net/localimg/localimages/07/mapapidoc/ico_plus.png" alt="확대"></span>  
            <span onclick="zoomOut()"><img src="https://t1.daumcdn.net/localimg/localimages/07/mapapidoc/ico_minus.png" alt="축소"></span>
        </div>
                """

                control_func = f"""
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

                mouse_over_func = f"""
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

                text = f"""
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title>지도 생성하기</title>

        <style>
            html, body {{width:100%;height:100%;margin:0;padding:0;}}
            .map_wrap {{position:relative;overflow:hidden;width:100%;height:100%;}}
            {control_style if self.control else ""}
        </style>
    </head>

    <body>
    <div class="map_wrap">
        <div id="map" style="width:100%;height:100%;position:relative;overflow:hidden;"></div>
        {control_div if self.control else ""}
        <div id="clickLatlng">{self.map_center["lat"]} {self.map_center["lng"]}</div>
    </div>

    <script type="text/javascript" src="//dapi.kakao.com/v2/maps/sdk.js?appkey=36e6f8ef91e206312c99c8be04e55526"></script>
    <script>
        {control_func if self.control else ""}
        {mouse_over_func if self.mouse_over else ""}
    """

                text += f"""
        // 지도 생성
        var mapContainer = document.getElementById('map'),
        mapOption = {{
            center: new kakao.maps.LatLng({self.map_center["lat"]}, {self.map_center["lng"]}),
            level: {self.map_center["level"]}
        }};
        var map = new kakao.maps.Map(mapContainer, mapOption);
        """

                if self.map_click:
                    text += """
            kakao.maps.event.addListener(map, 'click', function(mouseEvent) {

            var latlng = mouseEvent.latLng; 

            marker.setPosition(latlng);

            var message = latlng.getLat() +  ' ' + latlng.getLng();

            var resultDiv = document.getElementById('clickLatlng'); 
            resultDiv.innerHTML = message;

            });
                            """

                # --- 타이틀 확인
                title = ""
                if self.map_center['title'] != "":
                    title = "title: '" + self.map_center['title'] + "', "

                # --- 인포 확인
                content = ""
                if self.map_center['content'] != "":
                    content = f"""
            // 마커의 인포 생성
            var infowindow = new kakao.maps.InfoWindow({{
                content: '<div style = "padding:5px;">{self.map_center['content']}</div>'
                }});
            """
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

                text += f"""
            // 메인 마커 생성
            var markerPosition = new kakao.maps.LatLng({self.map_center['lat']}, {self.map_center['lng']});
            var marker = new kakao.maps.Marker({{
                {title}
                position: markerPosition
            }});
            marker.setMap(map);
            {content}
            """

                html_text += text

            elif _type == "end":
                text = f"""
    </script>
    </body>
</html>"""

                html_text += text

            elif _type == "custom_marker":
                text = """
        // 커스텀 마커 생성
        var positions = ["""

                for idx, position in enumerate(_data['positions']):
                    text += f"""
            {{
                title: '{position['title']}',
                latlng: new kakao.maps.LatLng({position['LatLng'][0]}, {position['LatLng'][1]})
            }}
            """
                    if idx < len(_data['positions']) - 1:
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
        }}
        """
                html_text += text

        return html_text

    def save_map(self, file_path: str):
        with open(file_path, 'w', encoding='UTF-8') as html_file:
            html_file.write(self.html())

    # 지도 생성
    def create_map(self, lat, lng, level=3, title="", content=""):
        self.map_center = {"lat": lat, "lng": lng, "title": title, "content": content, "level": level}

    def create_main_marker(self):
        self.main_marker = True

    # 마커 생성
    def create_custom_marker(self, positions: list):
        # "positions": [{"title": "현화중학교", "LatLng": (36.9824163015563, 126.92003340131), "content": "중학교 정보입니다."}]
        self.custom.append({"header": "custom_marker", 'index': {"positions": positions}})

    def set_control(self, control: bool):
        self.control = control

    def set_map_click(self, click: bool):
        self.map_click = click

    def set_mouse_over(self, over: bool):
        self.mouse_over = over



