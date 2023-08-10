namespace analysis_paris.View {
    public static class SplashScreen {
        static SplashWindow sw = null;

        public static void ShowSplashScreen() {
            if (sw == null) {
                sw = new SplashWindow();
                sw.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                sw.ShowSplashScreen();
            }
        }

        public static void CloseSplashScreen() {
            if (sw != null) {
                sw.CloseSplashScreen();
                sw = null;
            }
        }

    }
}
