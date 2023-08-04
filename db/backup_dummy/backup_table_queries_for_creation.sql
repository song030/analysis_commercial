-- 백업용 쿼리문 필요없어지면 지울 예정

-- #################
-- ### 테이블 설정 ###
-- #################


-- 학원 테이블
-- Table: public.TB_ACADEMY
DROP TABLE IF EXISTS public."TB_ACADEMY";
CREATE TABLE IF NOT EXISTS public."TB_ACADEMY"
(
    "SHOP_NUM" character varying COLLATE pg_catalog."default",
    "SHOP_NAME" character varying COLLATE pg_catalog."default",
    "SHOP_TYPE" character varying COLLATE pg_catalog."default",
    "STANDARD_CODE" character varying COLLATE pg_catalog."default",
    "STANDARD_NAME" character varying COLLATE pg_catalog."default",
    "CITY_CODE" integer,
    "CITY_NAME" character varying COLLATE pg_catalog."default",
    "ROAD_NAME" character varying COLLATE pg_catalog."default",
    "BUILDING_NAME" character varying COLLATE pg_catalog."default",
    "ROAD_ADDRESS" character varying COLLATE pg_catalog."default",
    "LATITUDE" double precision,
    "LONGITUDE" double precision
)
TABLESPACE pg_default;
ALTER TABLE IF EXISTS public."TB_ACADEMY" OWNER to postgres;


-- 횡당보도 테이블
-- Table: public.TB_CROSSWALK
 DROP TABLE IF EXISTS public."TB_CROSSWALK";
CREATE TABLE IF NOT EXISTS public."TB_CROSSWALK"
(
    "CROSSWALK_ID" serial PRIMARY KEY,
    "DO_NAME" character varying COLLATE pg_catalog."default",
    "CITY_NAME" character varying COLLATE pg_catalog."default",
    "ROAD_NAME" character varying COLLATE pg_catalog."default",
    "BRANCH_ADDRESS" character varying COLLATE pg_catalog."default",
    "MANAGE_NUM" character varying COLLATE pg_catalog."default",
    "LATITUDE" double precision,
    "LONGITUDE" double precision,
    "CROSSWALK_ID" integer NOT NULL DEFAULT 'nextval('"TB_CROSSWALK_ID_seq"'::regclass)',
    CONSTRAINT "TB_CROSSWALK_pkey" PRIMARY KEY ("CROSSWALK_ID")
)
TABLESPACE pg_default;
ALTER TABLE IF EXISTS public."TB_CROSSWALK" OWNER to postgres;

-- 병원 테이블
-- Table: public.TB_HOSPITAL
 DROP TABLE IF EXISTS public."TB_HOSPITAL";
CREATE TABLE IF NOT EXISTS public."TB_HOSPITAL"
(
    "GOVERNMENT_CODE" integer,
    "MANAGE_CODE" character varying COLLATE pg_catalog."default",
    "LICENSE_DATE" character varying COLLATE pg_catalog."default",
    "BUSINESS_STATUS" character varying COLLATE pg_catalog."default",
    "STATE_CODE" integer,
    "STATE_NAME" character varying COLLATE pg_catalog."default",
    "TEL" character varying COLLATE pg_catalog."default",
    "ROAD_ADDRESS" character varying COLLATE pg_catalog."default",
    "BUSINESS_NAME" character varying COLLATE pg_catalog."default",
    "BUSINESS_TYPE" character varying COLLATE pg_catalog."default",
    latitude double precision,
    longitude double precision,
    "ID" integer NOT NULL DEFAULT 'nextval('"TB_HOSPITAL_ID_seq"'::regclass)',
    CONSTRAINT "TB_HOSPITAL_pkey" PRIMARY KEY ("ID")
)
TABLESPACE pg_default;
ALTER TABLE IF EXISTS public."TB_HOSPITAL" OWNER to postgres;


-- 거주 세대 테이블
-- Table: public.TB_LIVING_INFO
 DROP TABLE IF EXISTS public."TB_LIVING_INFO";
CREATE TABLE IF NOT EXISTS public."TB_LIVING_INFO"
(
    "LVN_ADDRESS" character varying COLLATE pg_catalog."default",
    "LVN_NAME" character varying COLLATE pg_catalog."default",
    "LVN_COUNT" integer,
    "LVN_FAMILY" integer,
    "LVN_DATE" character varying COLLATE pg_catalog."default",
    latitude double precision,
    longitude double precision,
    "LVN_NO" integer NOT NULL DEFAULT 'nextval('"TB_LIVING_INFO_LVN_NO_seq"'::regclass)',
    CONSTRAINT "TB_LIVING_INFO_pkey" PRIMARY KEY ("LVN_NO")
)
TABLESPACE pg_default;
ALTER TABLE IF EXISTS public."TB_LIVING_INFO" OWNER to postgres;

-- 파리바게트 테이블
-- Table: public.TB_PARIS
 DROP TABLE IF EXISTS public."TB_PARIS";
CREATE TABLE IF NOT EXISTS public."TB_PARIS"
(
    "PARIS_NAME" character varying COLLATE pg_catalog."default",
    "PARIS_ADDRESS" character varying COLLATE pg_catalog."default",
    latitude double precision,
    longitude double precision,
    "PARIS_NO" integer NOT NULL DEFAULT 'nextval('"TB_PARIS_PARIS_NO_seq"'::regclass)',
    CONSTRAINT "TB_PARIS_pkey" PRIMARY KEY ("PARIS_NO")
)
TABLESPACE pg_default;
ALTER TABLE IF EXISTS public."TB_PARIS" OWNER to postgres;

-- 주차장 정보 테이블
-- Table: public.TB_PARKING
 DROP TABLE IF EXISTS public."TB_PARKING";
CREATE TABLE IF NOT EXISTS public."TB_PARKING"
(
    "MANAGE_NUMBER" character varying COLLATE pg_catalog."default",
    "PARKING_NAME" character varying COLLATE pg_catalog."default",
    "PARKING_CLASS" character varying COLLATE pg_catalog."default",
    "PARKING_TYPE" character varying COLLATE pg_catalog."default",
    "ROAD_ADDRESS" character varying COLLATE pg_catalog."default",
    "BRANCH_ADDRESS" character varying COLLATE pg_catalog."default",
    "PARKING_SAPCE" integer,
    "TEL" character varying COLLATE pg_catalog."default",
    "LATITUDE" double precision,
    "LONGITUDE" double precision,
    "ID" integer NOT NULL DEFAULT 'nextval('"TB_PARKING_ID_seq"'::regclass)',
    CONSTRAINT "TB_PARKING_pkey" PRIMARY KEY ("ID")
)
TABLESPACE pg_default;
ALTER TABLE IF EXISTS public."TB_PARKING" OWNER to postgres;

-- 상권 정보 테이블
-- Table: public.TB_SALES
 DROP TABLE IF EXISTS public."TB_SALES";
CREATE TABLE IF NOT EXISTS public."TB_SALES"
(
    "BASE_YEAR" integer,
    "BASE_QUARTER" integer,
    "COMM_ID" integer NOT NULL,
    "COMM_NAME" character varying COLLATE pg_catalog."default",
    "INDUSTRY_CODE" integer,
    "INDUSTRY_NAME" character varying COLLATE pg_catalog."default",
    "SALE_AMT" integer,
    "SALE_NUM" integer,
    "ROAD_ADDRESS" character varying COLLATE pg_catalog."default",
    latitude double precision,
    longitude double precision,
    CONSTRAINT "TB_SALES_pkey" PRIMARY KEY ("COMM_ID")
)
TABLESPACE pg_default;
ALTER TABLE IF EXISTS public."TB_SALES" OWNER to postgres;


-- 학교 정보 테이블
-- Table: public.TB_SCHOOL
 DROP TABLE IF EXISTS public."TB_SCHOOL";
CREATE TABLE IF NOT EXISTS public."TB_SCHOOL"
(
    "FACILITY_EDU_CODE" integer,
    "FACILITY_EDU_NAME" character varying COLLATE pg_catalog."default",
    "OFFICE_EDU_CODE" integer,
    "OFFICE_EDU_NAME" character varying COLLATE pg_catalog."default",
    "DO_CODE" integer,
    "DO_NAME" character varying COLLATE pg_catalog."default",
    "CITY_CODE" integer,
    "CITY_NAME" character varying COLLATE pg_catalog."default",
    "SCHOOL_NAME" character varying COLLATE pg_catalog."default",
    "PUBLIC_PRIVATE" character varying COLLATE pg_catalog."default",
    "EST_TYPE" character varying COLLATE pg_catalog."default",
    "EST_DATE" character varying COLLATE pg_catalog."default",
    "SCHOOL_CHAR" character varying COLLATE pg_catalog."default",
    "DAY_NIGHT" character varying COLLATE pg_catalog."default",
    "NUM_CLASS" integer,
    "NUM_STUDENT" integer,
    "NUM_TEACHER" integer,
    "NUM_SPECIAL_CLASS" integer,
    "ROAD_ADDRESS" character varying COLLATE pg_catalog."default",
    "HOMEPAGE" character varying COLLATE pg_catalog."default",
    "TEL" character varying COLLATE pg_catalog."default",
    "FAX" character varying COLLATE pg_catalog."default",
    "MALE_FEMALE" character varying COLLATE pg_catalog."default",
    "ID" integer NOT NULL DEFAULT 'nextval('"TB_SCHOOL_ID_seq"'::regclass)',
    latitude double precision,
    longitude double precision,
    CONSTRAINT "TB_SCHOOL_pkey" PRIMARY KEY ("ID")
)
TABLESPACE pg_default;
ALTER TABLE IF EXISTS public."TB_SCHOOL" OWNER to postgres;


-- 상가 매물 테이블
-- Table: public.TB_SELLING_AREA
 DROP TABLE IF EXISTS public."TB_SELLING_AREA";
CREATE TABLE IF NOT EXISTS public."TB_SELLING_AREA"
(
    "SELLING_AREA_ID" integer NOT NULL DEFAULT 'nextval('"TB_SELLING_AREA_SELLING_AREA_ID_seq"'::regclass)',
    "SELLING_TYPE" character varying COLLATE pg_catalog."default",
    "BUILDING_TYPE" character varying COLLATE pg_catalog."default",
    "CURRENT_STATE" character varying COLLATE pg_catalog."default",
    "ADDRESS" character varying COLLATE pg_catalog."default",
    "AREA_SIZE" double precision,
    "FLOOR_INFO" character varying COLLATE pg_catalog."default",
    "DEPOSIT" integer,
    "RATE_PER_MONTH" integer,
    "PREMIUM" integer,
    latitude double precision,
    longitude double precision,
    "RELATION_LINK" character varying COLLATE pg_catalog."default",
    "SELLING_PRICE" bigint,
    CONSTRAINT "TB_SELLING_AREA_pkey" PRIMARY KEY ("SELLING_AREA_ID")
)
TABLESPACE pg_default;
ALTER TABLE IF EXISTS public."TB_SELLING_AREA" OWNER to postgres;


-- 지하철 역정보 테이블
-- Table: public.TB_STATION
 DROP TABLE IF EXISTS public."TB_STATION";
CREATE TABLE IF NOT EXISTS public."TB_STATION"
(
    "STATION_LINE" character varying COLLATE pg_catalog."default",
    "STATION_NAME" character varying COLLATE pg_catalog."default",
    "BRANCH_ADDRESS" character varying COLLATE pg_catalog."default",
    "ROAD_ADDRESS" character varying COLLATE pg_catalog."default",
    latitude double precision,
    longitude double precision
)
TABLESPACE pg_default;
ALTER TABLE IF EXISTS public."TB_STATION" OWNER to postgres;


-- 버스정류장 테이블
-- Table: public.TB_STOP
 DROP TABLE IF EXISTS public."TB_STOP";
CREATE TABLE IF NOT EXISTS public."TB_STOP"
(
    "STOP_ID" integer,
    "CITY_NAME" character varying COLLATE pg_catalog."default",
    "STOP_NAME" character varying COLLATE pg_catalog."default",
    "LATITUDE" double precision,
    "LONGITUDE" double precision
)
TABLESPACE pg_default;
ALTER TABLE IF EXISTS public."TB_STOP" OWNER to postgres;


-- 관광지 테이블
-- Table: public.TB_TOUR
 DROP TABLE IF EXISTS public."TB_TOUR";
CREATE TABLE IF NOT EXISTS public."TB_TOUR"
(
    "TOUR_NAME" character varying COLLATE pg_catalog."default",
    "TOUR_ADDR_N" character varying COLLATE pg_catalog."default",
    "TOUR_ADDR_O" character varying COLLATE pg_catalog."default",
    latitude double precision,
    longitude double precision,
    "TOUR_ID" integer NOT NULL DEFAULT 'nextval('"TB_TOUR_TOUR_ID_seq"'::regclass)',
    CONSTRAINT "PK_TOUR_ID" PRIMARY KEY ("TOUR_ID")
)
TABLESPACE pg_default;
ALTER TABLE IF EXISTS public."TB_TOUR" OWNER to postgres;