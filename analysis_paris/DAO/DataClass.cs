using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace analysis_paris.DAO {
    public class Paris {
        public int PARIS_ID { get; set; }
        public string PARIS_NAME { get; set; }
        public string PARIS_ADDRESS { get; set; }
        public double LATITUDE { get; set; }
        public double LONGITUDE { get; set; }
        public double AREA_SIZE { get; set; }
        public DateTime? OPEN_DATE { get; set; }
        public DateTime? CLOSE_DATE { get; set; }
        public string IS_OPEN_STATE { get; set; }
        public int RIVAL_COUNT_NEAR_500 { get; set; }
        public int RIVAL_COUNT_NEAR_1000 { get; set; }
        public int MONTHLY_SHOP_REVENUE { get; set; }
        public int MONTHLY_SHOP_SALE_TRANSACTION_COUNT { get; set; }
        public int DAILY_FLOATING_POPULATION { get; set; }
        public int LIVING_WORKER_POPULATION { get; set; }
        public int LIVING_WORKER_AVG_REVENUE { get; set; }
        public int LIVING_POPULATION { get; set; }
        public int LIVING_POPULATION_AVG_REVENUE { get; set; }
        public int ATTRACTION_COUNT_NEAR_500 { get; set; }
        public int ATTRACTION_COUNT_NEAR_1000 { get; set; }
        public int ACADEMY_COUNT_NEAR_500 { get; set; }
        public int ACADEMY_COUNT_NEAR_1000 { get; set; }
        public int STOP_COUNT_NEAR_500 { get; set; }
        public int STOP_COUNT_NEAR_1000 { get; set; }
        public int CROSSWALK_COUNT_NEAR_500 { get; set; }
        public int CROSSWALK_COUNT_NEAR_1000 { get; set; }
        public int HOSPITAL_COUNT_NEAR_500 { get; set; }
        public int HOSPITAL_COUNT_NEAR_1000 { get; set; }
        public int PARKING_COUNT_NEAR_500 { get; set; }
        public int PARKING_COUNT_NEAR_1000 { get; set; }
        public int SCHOOL_COUNT_NEAR_500 { get; set; }
        public int SCHOOL_COUNT_NEAR_1000 { get; set; }
        public int STATION_COUNT_NEAR_500 { get; set; }
        public int STATION_COUNT_NEAR_1000 { get; set; }
        public int LIVING_COUNT_NEAR_500 { get; set; }
        public int LIVING_COUNT_NEAR_1000 { get; set; }
        public int RIVAL_NEAR_DISTANCE { get; set; }
        public int LIVING_NEAR_DISTANCE { get; set; }
        public int SCHOOL_NEAR_DISTANCE { get; set; }
        public int ACADEMY_NEAR_DISTANCE { get; set; }
        public int HOSPITAL_NEAR_DISTANCE { get; set; }
        public int STATION_NEAR_DISTANCE { get; set; }
        public int STOP_NEAR_DISTANCE { get; set; }
        public int PARKING_NEAR_DISTANCE { get; set; }
        public int ATTRACTION_NEAR_DISTANCE { get; set; }
        public int CROSSWALK_NEAR_DISTANCE { get; set; }
        public int LEISURE_COUNT_NEAR_500 { get; set; }
        public int LEISURE_COUNT_NEAR_1000 { get; set; }
        public int LEISURE_NEAR_DISTANCE { get; set; }
        public int SCORE { get; set; }

        public Dictionary<string, Tuple<string, string>> GetAttributes() {
            Dictionary<string, Tuple<string, string>> resultDict = new Dictionary<string, Tuple<string, string>>();
            resultDict.Add("SCORE", new Tuple<string, string>("점수", this.PARIS_NAME.ToString()));
            //resultDict.Add("PARIS_ID", new Tuple<string, string>("파리바게뜨 아이디", this.PARIS_ID.ToString()));
            resultDict.Add("PARIS_NAME", new Tuple<string, string>("상호명", this.PARIS_NAME.ToString()));
            resultDict.Add("PARIS_ADDRESS", new Tuple<string, string>("주소", this.PARIS_ADDRESS.ToString()));
            //resultDict.Add("LATITUDE", new Tuple<string, string>("위도", this.LATITUDE.ToString()));
            //resultDict.Add("LONGITUDE", new Tuple<string, string>("경도", this.LONGITUDE.ToString()));
            resultDict.Add("AREA_SIZE", new Tuple<string, string>("매장 크기", $"{this.AREA_SIZE}m²"));
            resultDict.Add("OPEN_DATE", new Tuple<string, string>("개업일자", this.OPEN_DATE.ToString()));
            resultDict.Add("CLOSE_DATE", new Tuple<string, string>("폐업일자", this.CLOSE_DATE.ToString()));
            resultDict.Add("IS_OPEN_STATE", new Tuple<string, string>("개점 여부", this.IS_OPEN_STATE.ToString()));
            resultDict.Add("RIVAL_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 경쟁업체 수(개)", this.RIVAL_COUNT_NEAR_500.ToString()));
            resultDict.Add("RIVAL_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 경쟁업체 수(개)", this.RIVAL_COUNT_NEAR_1000.ToString()));
            resultDict.Add("MONTHLY_SHOP_REVENUE", new Tuple<string, string>("추정 매달 수익(원)", this.MONTHLY_SHOP_REVENUE.ToString("#,##")));
            resultDict.Add("MONTHLY_SHOP_SALE_TRANSACTION_COUNT", new Tuple<string, string>("추정 매달 거래 건수(건)", this.MONTHLY_SHOP_SALE_TRANSACTION_COUNT.ToString("#,##")));
            resultDict.Add("DAILY_FLOATING_POPULATION", new Tuple<string, string>("일일 유동 인구(명)", this.DAILY_FLOATING_POPULATION.ToString("#,##")));
            resultDict.Add("LIVING_WORKER_POPULATION", new Tuple<string, string>("반경 500m 내 거주 근로자 수(명)", this.LIVING_WORKER_POPULATION.ToString("#,##")));
            resultDict.Add("LIVING_WORKER_AVG_REVENUE", new Tuple<string, string>("반경 500m 내 거주 근로자 평균 소득(원)", this.LIVING_WORKER_AVG_REVENUE.ToString("#,##")));
            resultDict.Add("LIVING_POPULATION", new Tuple<string, string>("반경 500m 내 거주 인구(명)", this.LIVING_POPULATION.ToString("#,##")));
            resultDict.Add("LIVING_POPULATION_AVG_REVENUE", new Tuple<string, string>("반경 500m 내 거주 인구 평균 소득(원)", this.LIVING_POPULATION_AVG_REVENUE.ToString("#,##")));
            resultDict.Add("ATTRACTION_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 관광명소 수(개)", this.ATTRACTION_COUNT_NEAR_500.ToString()));
            resultDict.Add("ATTRACTION_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 관광명소 수(개)", this.ATTRACTION_COUNT_NEAR_1000.ToString()));
            resultDict.Add("ACADEMY_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 학원 수(개)", this.ACADEMY_COUNT_NEAR_500.ToString()));
            resultDict.Add("ACADEMY_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 학원 수(개)", this.ACADEMY_COUNT_NEAR_1000.ToString()));
            resultDict.Add("STOP_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 버스정류장 수(개)", this.STOP_COUNT_NEAR_500.ToString()));
            resultDict.Add("STOP_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 버스정류장 수(개)", this.STOP_COUNT_NEAR_1000.ToString()));
            resultDict.Add("CROSSWALK_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 횡단보도 수(개)", this.CROSSWALK_COUNT_NEAR_500.ToString()));
            resultDict.Add("CROSSWALK_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 횡단보도 수(개)", this.CROSSWALK_COUNT_NEAR_1000.ToString()));
            resultDict.Add("HOSPITAL_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 병원 수(개)", this.HOSPITAL_COUNT_NEAR_500.ToString()));
            resultDict.Add("HOSPITAL_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 병원 수(개)", this.HOSPITAL_COUNT_NEAR_1000.ToString()));
            resultDict.Add("PARKING_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 주차장 수(개)", this.PARKING_COUNT_NEAR_500.ToString()));
            resultDict.Add("PARKING_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 주차장 수(개)", this.PARKING_COUNT_NEAR_1000.ToString()));
            resultDict.Add("SCHOOL_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 학교 수(개)", this.SCHOOL_COUNT_NEAR_500.ToString()));
            resultDict.Add("SCHOOL_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 학교 수(개)", this.SCHOOL_COUNT_NEAR_1000.ToString()));
            resultDict.Add("STATION_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 지하철역 수(개)", this.STATION_COUNT_NEAR_500.ToString()));
            resultDict.Add("STATION_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 지하철역 수(개)", this.STATION_COUNT_NEAR_1000.ToString()));
            resultDict.Add("LIVING_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 거주세대 수(세대)", this.LIVING_COUNT_NEAR_500.ToString()));
            resultDict.Add("LIVING_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 거주세대 수(세대)", this.LIVING_COUNT_NEAR_1000.ToString()));
            resultDict.Add("RIVAL_NEAR_DISTANCE", new Tuple<string, string>("가장 가까운 경쟁업체 거리(m)", this.RIVAL_NEAR_DISTANCE.ToString()));
            resultDict.Add("LIVING_NEAR_DISTANCE", new Tuple<string, string>("가장 가까운 거주세대 거리(m)", this.LIVING_NEAR_DISTANCE.ToString()));
            resultDict.Add("SCHOOL_NEAR_DISTANCE", new Tuple<string, string>("가장 가까운 학교 거리(m)", this.SCHOOL_NEAR_DISTANCE.ToString()));
            resultDict.Add("ACADEMY_NEAR_DISTANCE", new Tuple<string, string>("가장 가까운 학원 거리(m)", this.ACADEMY_NEAR_DISTANCE.ToString()));
            resultDict.Add("HOSPITAL_NEAR_DISTANCE", new Tuple<string, string>("가장 가까운 병원 거리(m)", this.HOSPITAL_NEAR_DISTANCE.ToString()));
            resultDict.Add("STATION_NEAR_DISTANCE", new Tuple<string, string>("가장 가까운 지하철역 거리(m)", this.STATION_NEAR_DISTANCE.ToString()));
            resultDict.Add("STOP_NEAR_DISTANCE", new Tuple<string, string>("가장 가까운 버스정류장 거리(m)", this.STOP_NEAR_DISTANCE.ToString()));
            resultDict.Add("PARKING_NEAR_DISTANCE", new Tuple<string, string>("가장 가까운 주차장 거리(m)", this.PARKING_NEAR_DISTANCE.ToString()));
            resultDict.Add("ATTRACTION_NEAR_DISTANCE", new Tuple<string, string>("가장 가까운 관광명소 거리(m)", this.ATTRACTION_NEAR_DISTANCE.ToString()));
            resultDict.Add("CROSSWALK_NEAR_DISTANCE", new Tuple<string, string>("가장 가까운 횡단보도 거리(m)", this.CROSSWALK_NEAR_DISTANCE.ToString()));
            resultDict.Add("LEISURE_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 여가시설 수(개)", this.LEISURE_COUNT_NEAR_500.ToString()));
            resultDict.Add("LEISURE_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 여가시설 수(개)", this.LEISURE_COUNT_NEAR_1000.ToString()));
            resultDict.Add("LEISURE_NEAR_DISTANCE", new Tuple<string, string>("가장 가까운 여가시설 거리(m)", this.LEISURE_NEAR_DISTANCE.ToString("#,##")));
            return resultDict;
        }
    }

    public class SellingArea {

        public int SELLING_AREA_ID { get; set; }
        public string SELLING_TYPE { get; set; }
        public string BUILDING_TYPE { get; set; }
        public string CURRENT_STATE { get; set; }
        public string ADDRESS { get; set; }
        public double AREA_SIZE { get; set; }
        public int FLOOR_INFO { get; set; }
        public int TOTAL_FLOOR { get; set; }
        public int DEPOSIT { get; set; }
        public int RATE_PER_MONTH { get; set; }
        public int PREMIUM { get; set; }
        public double LATITUDE { get; set; }
        public double LONGITUDE { get; set; }
        public string RELATION_LINK { get; set; }
        public int SELLING_PRICE { get; set; }
        public int RIVAL_COUNT_NEAR_500 { get; set; }
        public int RIVAL_COUNT_NEAR_1000 { get; set; }
        public int MONTHLY_SHOP_REVENUE { get; set; }
        public int MONTHLY_SHOP_SALE_TRANSACTION_COUNT { get; set; }
        public int DAILY_FLOATING_POPULATION { get; set; }
        public int LIVING_WORKER_POPULATION { get; set; }
        public int LIVING_WORKER_AVG_REVENUE { get; set; }
        public int LIVING_POPULATION { get; set; }
        public int LIVING_POPULATION_AVG_REVENUE { get; set; }
        public int ATTRACTION_COUNT_NEAR_500 { get; set; }
        public int ATTRACTION_COUNT_NEAR_1000 { get; set; }
        public int ACADEMY_COUNT_NEAR_500 { get; set; }
        public int ACADEMY_COUNT_NEAR_1000 { get; set; }
        public int STOP_COUNT_NEAR_500 { get; set; }
        public int STOP_COUNT_NEAR_1000 { get; set; }
        public int CROSSWALK_COUNT_NEAR_500 { get; set; }
        public int CROSSWALK_COUNT_NEAR_1000 { get; set; }
        public int HOSPITAL_COUNT_NEAR_500 { get; set; }
        public int HOSPITAL_COUNT_NEAR_1000 { get; set; }
        public int PARKING_COUNT_NEAR_500 { get; set; }
        public int PARKING_COUNT_NEAR_1000 { get; set; }
        public int SCHOOL_COUNT_NEAR_500 { get; set; }
        public int SCHOOL_COUNT_NEAR_1000 { get; set; }
        public int STATION_COUNT_NEAR_500 { get; set; }
        public int STATION_COUNT_NEAR_1000 { get; set; }
        public int LIVING_COUNT_NEAR_500 { get; set; }
        public int LIVING_COUNT_NEAR_1000 { get; set; }
        public int LEISURE_COUNT_NEAR_500 { get; set; }
        public int LEISURE_COUNT_NEAR_1000 { get; set; }
        public int SCORE { get; set; }
        public int MART_COUNT_NEAR_500 { get; set; }
        public int MART_COUNT_NEAR_1000 { get; set; }
        public int EXPECTED_SHOP_REVENUE { get; set; }


        public Dictionary<string, Tuple<string, string>> GetAttributes() {
            Dictionary<string, Tuple<string, string>> resultDict = new Dictionary<string, Tuple<string, string>>();
            resultDict.Add("SCORE", new Tuple<string, string>("점수", this.SCORE.ToString()));
            //resultDict.Add("SELLING_AREA_ID ", new Tuple<string, string>("매물 아이디", this.SELLING_AREA_ID.ToString()));
            resultDict.Add("SELLING_TYPE", new Tuple<string, string>("매물 타입", this.SELLING_TYPE.ToString()));
            resultDict.Add("BUILDING_TYPE", new Tuple<string, string>("시설 분류", this.BUILDING_TYPE.ToString()));
            resultDict.Add("CURRENT_STATE", new Tuple<string, string>("현재 업종", this.CURRENT_STATE.ToString()));
            resultDict.Add("ADDRESS", new Tuple<string, string>("주소", this.ADDRESS.ToString()));
            resultDict.Add("AREA_SIZE", new Tuple<string, string>("매물 면적", this.AREA_SIZE.ToString("#,##m²")));
            //resultDict.Add("FLOOR_INFO", new Tuple<string, string>("층수", this.FLOOR_INFO.ToString()));
            //resultDict.Add("TOTAL_FLOOR", new Tuple<string, string>("전체 층수", this.TOTAL_FLOOR.ToString()));
            resultDict.Add("DEPOSIT", new Tuple<string, string>("보증금(만원)", this.DEPOSIT.ToString("#,##")));
            resultDict.Add("RATE_PER_MONTH", new Tuple<string, string>("월세(만원)", this.RATE_PER_MONTH.ToString("#,##")));
            resultDict.Add("PREMIUM", new Tuple<string, string>("권리금(만원)", this.PREMIUM.ToString("#,##")));
            //resultDict.Add("LATITUDE", new Tuple<string, string>("위도", this.LATITUDE.ToString()));
            //resultDict.Add("LONGITUDE", new Tuple<string, string>("경도", this.LONGITUDE.ToString()));
            //resultDict.Add("RELATION_LINK", new Tuple<string, string>("링크", this.RELATION_LINK.ToString()));
            resultDict.Add("SELLING_PRICE", new Tuple<string, string>("매매가(만원)", this.SELLING_PRICE.ToString("#,##")));
            resultDict.Add("RIVAL_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 경쟁업체 수(개)", this.RIVAL_COUNT_NEAR_500.ToString()));
            resultDict.Add("RIVAL_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 경쟁업체 수(개)", this.RIVAL_COUNT_NEAR_1000.ToString()));
            resultDict.Add("MONTHLY_SHOP_REVENUE", new Tuple<string, string>("추정 매달 수익(원)", this.MONTHLY_SHOP_REVENUE.ToString("#,##")));
            resultDict.Add("MONTHLY_SHOP_SALE_TRANSACTION_COUNT", new Tuple<string, string>("추정 매달 거래 건수(건)", this.MONTHLY_SHOP_SALE_TRANSACTION_COUNT.ToString("#,##")));
            resultDict.Add("DAILY_FLOATING_POPULATION", new Tuple<string, string>("일일 유동 인구(명)", this.DAILY_FLOATING_POPULATION.ToString("#,##")));
            resultDict.Add("LIVING_WORKER_POPULATION", new Tuple<string, string>("반경 500m 내 거주 근로자 수(명)", this.LIVING_WORKER_POPULATION.ToString("#,##")));
            resultDict.Add("LIVING_WORKER_AVG_REVENUE", new Tuple<string, string>("반경 500m 내 거주 근로자 평균 소득(원)", this.LIVING_WORKER_AVG_REVENUE.ToString("#,##")));
            resultDict.Add("LIVING_POPULATION", new Tuple<string, string>("반경 500m 내 거주 인구(명)", this.LIVING_POPULATION.ToString("#,##")));
            resultDict.Add("LIVING_POPULATION_AVG_REVENUE", new Tuple<string, string>("반경 500m 내 거주 인구 평균 소득(원)", this.LIVING_POPULATION_AVG_REVENUE.ToString("#,##")));
            resultDict.Add("ATTRACTION_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 관광명소 수(개)", this.ATTRACTION_COUNT_NEAR_500.ToString()));
            resultDict.Add("ATTRACTION_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 관광명소 수(개)", this.ATTRACTION_COUNT_NEAR_1000.ToString()));
            resultDict.Add("ACADEMY_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 학원 수(개)", this.ACADEMY_COUNT_NEAR_500.ToString()));
            resultDict.Add("ACADEMY_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 학원 수(개)", this.ACADEMY_COUNT_NEAR_1000.ToString()));
            resultDict.Add("STOP_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 버스정류장 수(개)", this.STOP_COUNT_NEAR_500.ToString()));
            resultDict.Add("STOP_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 버스정류장 수(개)", this.STOP_COUNT_NEAR_1000.ToString()));
            resultDict.Add("CROSSWALK_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 횡단보도 수(개)", this.CROSSWALK_COUNT_NEAR_500.ToString()));
            resultDict.Add("CROSSWALK_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 횡단보도 수(개)", this.CROSSWALK_COUNT_NEAR_1000.ToString()));
            resultDict.Add("HOSPITAL_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 병원 수(개)", this.HOSPITAL_COUNT_NEAR_500.ToString()));
            resultDict.Add("HOSPITAL_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 병원 수(개)", this.HOSPITAL_COUNT_NEAR_1000.ToString()));
            resultDict.Add("PARKING_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 주차장 수(개)", this.PARKING_COUNT_NEAR_500.ToString()));
            resultDict.Add("PARKING_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 주차장 수(개)", this.PARKING_COUNT_NEAR_1000.ToString()));
            resultDict.Add("SCHOOL_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 학교 수(개)", this.SCHOOL_COUNT_NEAR_500.ToString()));
            resultDict.Add("SCHOOL_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 학교 수(개)", this.SCHOOL_COUNT_NEAR_1000.ToString()));
            resultDict.Add("STATION_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 지하철역 수(개)", this.STATION_COUNT_NEAR_500.ToString()));
            resultDict.Add("STATION_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 지하철역 수(개)", this.STATION_COUNT_NEAR_1000.ToString()));
            resultDict.Add("LIVING_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 거주세대 수(세대)", this.LIVING_COUNT_NEAR_500.ToString()));
            resultDict.Add("LIVING_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 거주세대 수(세대)", this.LIVING_COUNT_NEAR_1000.ToString()));
            resultDict.Add("LEISURE_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 여가시설 수(개)", this.LEISURE_COUNT_NEAR_500.ToString()));
            resultDict.Add("LEISURE_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 여가시설 수(개)", this.LEISURE_COUNT_NEAR_1000.ToString()));
            resultDict.Add("MART_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 마트 수(개)", this.MART_COUNT_NEAR_500.ToString()));
            resultDict.Add("MART_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 마트 수(개)", this.MART_COUNT_NEAR_1000.ToString()));
            resultDict.Add("EXPECTED_SHOP_REVENUE", new Tuple<string, string>("예측 추정 월수익(원)", this.EXPECTED_SHOP_REVENUE.ToString("#,##")));
            return resultDict;
        }
    }

    public class LocationInfoDTO {

        public int score { get; set; }
        public int SCHOOL_COUNT_NEAR_500 { get; set; }
        public int SCHOOL_COUNT_NEAR_1000 { get; set; }
        public int ACADEMY_COUNT_NEAR_500 { get; set; }
        public int ACADEMY_COUNT_NEAR_1000 { get; set; }
        public int STATION_COUNT_NEAR_500 { get; set; }
        public int STATION_COUNT_NEAR_1000 { get; set; }
        public int STOP_COUNT_NEAR_500 { get; set; }
        public int STOP_COUNT_NEAR_1000 { get; set; }
        public int LEISURE_COUNT_NEAR_500 { get; set; }
        public int LEISURE_COUNT_NEAR_1000 { get; set; }
        public int DAILY_FLOATING_POPULATION { get; set; }
        public int LIVING_POPULATION { get; set; }
        public int LIVING_WORKER_AVG_REVENUE { get; set; }
        public int LIVING_POPULATION_AVG_REVENUE { get; set; }
        public int MONTHLY_SHOP_REVENUE { get; set; }
        public int RIVAL_COUNT_NEAR_500 { get; set; }
        public int RIVAL_COUNT_NEAR_1000 { get; set; }
        public double LATITUDE { get; set; }
        public double LONGITUDE { get; set; }
        public int EXPECTED_SHOP_REVENUE { get; set; }

        public Dictionary<string, Tuple<string, string>> GetAttributes() {
            Dictionary<string, Tuple<string, string>> resultDict = new Dictionary<string, Tuple<string, string>>();
            resultDict.Add("score", new Tuple<string, string>("점수", this.score.ToString()));
            resultDict.Add("SCHOOL_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 학교 수(개)", this.SCHOOL_COUNT_NEAR_500.ToString()));
            resultDict.Add("SCHOOL_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 학교 수(개)", this.SCHOOL_COUNT_NEAR_1000.ToString()));
            resultDict.Add("ACADEMY_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 학원 수(개)", this.ACADEMY_COUNT_NEAR_500.ToString()));
            resultDict.Add("ACADEMY_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 학원 수(개)", this.ACADEMY_COUNT_NEAR_1000.ToString()));
            resultDict.Add("STATION_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 지하철역 수(개)", this.STATION_COUNT_NEAR_500.ToString()));
            resultDict.Add("STATION_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 지하철역 수(개)", this.STATION_COUNT_NEAR_1000.ToString()));
            resultDict.Add("STOP_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 버스정류장 수(개)", this.STOP_COUNT_NEAR_500.ToString()));
            resultDict.Add("STOP_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 버스정류장 수(개)", this.STOP_COUNT_NEAR_1000.ToString()));
            resultDict.Add("LEISURE_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 여가시설 수(개)", this.LEISURE_COUNT_NEAR_500.ToString()));
            resultDict.Add("LEISURE_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 여가시설 수(개)", this.LEISURE_COUNT_NEAR_1000.ToString()));
            resultDict.Add("DAILY_FLOATING_POPULATION", new Tuple<string, string>("일일 유동 인구(명)", this.DAILY_FLOATING_POPULATION.ToString("#,##")));
            resultDict.Add("LIVING_POPULATION", new Tuple<string, string>("반경 500m 내 거주 인구(명)", this.LIVING_POPULATION.ToString("#,##")));
            resultDict.Add("LIVING_WORKER_AVG_REVENUE", new Tuple<string, string>("반경 500m 내 거주 근로자 평균 소득(원)", this.LIVING_WORKER_AVG_REVENUE.ToString("#,##")));
            resultDict.Add("LIVING_POPULATION_AVG_REVENUE", new Tuple<string, string>("반경 500m 내 거주 인구 평균 소득(원)", this.LIVING_POPULATION_AVG_REVENUE.ToString("#,##")));
            resultDict.Add("MONTHLY_SHOP_REVENUE", new Tuple<string, string>("추정 매달 수익(원)", this.MONTHLY_SHOP_REVENUE.ToString("#,##")));
            resultDict.Add("RIVAL_COUNT_NEAR_500", new Tuple<string, string>("반경 500m 내 경쟁업체 수(개)", this.RIVAL_COUNT_NEAR_500.ToString()));
            resultDict.Add("RIVAL_COUNT_NEAR_1000", new Tuple<string, string>("반경 1000m 내 경쟁업체 수(개)", this.RIVAL_COUNT_NEAR_1000.ToString()));
            //resultDict.Add("LATITUDE", new Tuple<string, string>("위도", this.LATITUDE.ToString()));
            //resultDict.Add("LONGITUDE", new Tuple<string, string>("경도", this.LONGITUDE.ToString()));
            resultDict.Add("EXPECTED_SHOP_REVENUE", new Tuple<string, string>("예측 추정 월수익(원)", this.EXPECTED_SHOP_REVENUE.ToString("#,##")));
            return resultDict;
        }
    }

    public class JSONConverter {
        public static List<Paris> JSONConverterParis(string json_str) {
            var parisList = JsonConvert.DeserializeObject<List<Paris>>(json_str);
            return parisList;
        }
        public static List<SellingArea> JSONConverterSellingArea(string json_str) {
            var sellingAreaList = JsonConvert.DeserializeObject<List<SellingArea>>(json_str);
            return sellingAreaList;
        }
        public static LocationInfoDTO JSONConverterLocationInfo(string json_str) {
            // todo 
            var locationInfo = JsonConvert.DeserializeObject<LocationInfoDTO>(json_str);
            return locationInfo;
        }

    }

}
