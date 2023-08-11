namespace analysis_paris.View {
    public static class SplashScreen {

        static SplashWindow sw = null;

        // 로딩 화면 출력
        public static void ShowSplashScreen() {
            if (sw == null) {
                sw = new SplashWindow();
                sw.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                sw.ShowSplashScreen();
            }
        }

        // 로딩 화면 닫기
        public static void CloseSplashScreen() {
            if (sw != null) {
                sw.CloseSplashScreen();
                sw = null;
            }
        }

        // 경영 화면 출력
        public static void ShowGyeongYeong() {
            if (sw == null) {
                sw = new SplashWindow(Properties.Resources.go_ahead);
                sw.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                sw.Opacity = 0.02;
                sw.opacityTimer.Enabled = true;
                sw.ShowSplashScreen();
            }
        }

    }
}
