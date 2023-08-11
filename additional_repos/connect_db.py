from sqlalchemy import create_engine

class Databases():
    def __init__(self):
        self.engine = create_engine('postgresql://postgres:1234@10.10.20.117:5432/db_analysis_test')
    def __del__(self):
        self.engine.dispose()