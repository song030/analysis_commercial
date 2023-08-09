# -----------------------------------------------------------
# 파이썬으로 웹서버로 파일을 업로드하는 파이썬 파일입니다.
# 작성자 : 송민정
# 작성일자 : 2023-08-08
# 명령어 예시 :
#       ex) ftp = FTP() : 객체 생성
#       ex) ftp.connect() : 웹서버 연결
#       ex) ftp.save_file(file_path) : 파일 저장
#           file_path : 저장할 파일의 경로, 절대경로롤 입력 할 것
#       ex) ftp.disconnect() : 웹서버 연결 해제
# 예상 리턴은 관련 함수를 검색바랍니다.
# -----------------------------------------------------------

import ftplib


HOST = "song030s.dothome.co.kr"
PORT = 21
ID = "song030s"
PWD = "q1w2e3r4!"


class FTP:

    def __init__(self):
        self.ftp = ftplib.FTP()

    def connect(self):
        self.ftp.connect(HOST, 21)
        self.ftp.login(ID, PWD)

    def disconnect(self):
        self.ftp.quit()

    def save_file(self, file_path: str):
        # 입력한 경로에서 파일이름만 분리
        file_name = file_path.split('/')
        file_name = file_name[-1]
        # print("ftp - 저장 파일 이름 : "+file_name)

        try:
            # 파일이름에서 확장자 분리
            extension = file_name.split('.')
            extension = extension[-1]

            # 파일 확장자에 따라 웹서버 저장 폴더 달라짐
            if extension == 'gif':
                save_folder = "Graph"
            elif extension == 'html':
                save_folder = "Map"
            else:
                raise Exception('잘못된 파일이름 입니다.')

            self.ftp.cwd("/html/" + save_folder)
            # print("ftp - 파일저장 경로 : /html/" + save_folder)

            file = open(file_path, mode='rb')

            # 파일 전송
            self.ftp.encoding = 'utf-8'
            self.ftp.storbinary('STOR ' + file_name, file)

            file.close()
            # print("전송 완료")

        except Exception as e:
            print("FTP Error : ", e)



