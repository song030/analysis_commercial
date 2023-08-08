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
    }

    public class SellingArea {
        public int SELLING_AREA_ID { get; set; }
        public string SELLING_TYPE { get; set; }
        public string BUILDING_TYPE { get; set; }
        public string CURRENT_STATE { get; set; }
        public string ADDRESS { get; set; }
        public double AREA_SIZE { get; set; }
        public string FLOOR_INFO { get; set; }
        public long DEPOSIT { get; set; }
        public long RATE_PER_MONTH { get; set; }
        public long PREMIUM { get; set; }
        public double LATITUDE { get; set; }
        public double LONGITUDE { get; set; }
        public string RELATION_LINK { get; set; }
        public long SELLING_PRICE { get; set; }
        public int RIVAL_CNT_300 { get; set; }
        public int TOUR_CNT_300 { get; set; }
        public int HOSPITAL_CNT_300 { get; set; }
        public int STOP_CNT_300 { get; set; }
        public int LIVING_CNT_300 { get; set; }
        public int PARKING_CNT_300 { get; set; }
        public int STATION_CNT_300 { get; set; }
        public int SCHOOL_CNT_300 { get; set; }
        public int ACADEMY_CNT_300 { get; set; }
        public int CROSSWALK_CNT_300 { get; set; }
    }

    public class JSONConverter {
        public static List<Paris> JSONConverterParis(string json_str) {
            var parisList = JsonConvert.DeserializeObject<List<Paris>>(json_str);
            return parisList;
        }
        public static List<SellingArea> JSONConverterSellingArea(string json_str) {
            var parisList = JsonConvert.DeserializeObject<List<SellingArea>>(json_str);
            return parisList;
        }

    }

}
