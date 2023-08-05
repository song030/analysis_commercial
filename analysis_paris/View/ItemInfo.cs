namespace analysis_paris.View {
    public class ItemInfo {


        #region Properties
        private int _id;
        private string _type;
        private string _addr;
        private int _score;

        public int ItemId {
            get { return _id; }
            set { _id = value; }
        }

        public string ItemType {
            get { return _type; }
            set { _type = value; }
        }

        public string ItemAddr {
            get { return _addr; }
            set { _addr = value; }
        }

        public int ItemScore {
            get { return _score; }
            set { _score = value; }
        }
        #endregion

        public ItemInfo(int itemId, string itemType, string itemAddr, int itemScore) {
            _id = itemId;
            _type = itemType;
            _addr = itemAddr;
            _score = itemScore;
        }
    }
}
