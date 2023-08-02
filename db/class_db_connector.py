import psycopg2


class DBConnector:
    # ===================== BASIC ============================ #
    _instance = None
    CONFIG_PATH = r"db_configuration.json"

    def __new__(cls, test_option=False):
        if not isinstance(cls._instance, cls):
            cls._instance = object.__new__(cls)
        return cls._instance

    def __init__(self, test_option=False):
        self.conn = None
        self.test_option = test_option

    def start_conn(self):
        if self.test_option is False:
            self.conn = psycopg2.connect('')
        else:
            self.conn = psycopg2.connect('')
        return self.conn.cursor()

    def end_conn(self):
        if self.conn is not None:
            self.conn.close()
            self.conn = None

    def commit_db(self):
        self.conn.commit()
