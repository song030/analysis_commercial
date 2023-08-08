using System;
using System.Diagnostics;

namespace analysis_paris.Factory {
    // ========================== Product 관련 클래스
    // IButton 추상 클래스
    public abstract class IButton {
        public string scriptPath = @"C:\Users\kdt99\source\repos\analysis_paris\analysis_paris\bin\Debug\python_controller.py";

        public abstract string RunScript();

        public string RunPythonScript(string scriptPath, string parameters) {
            // ProcessStartInfo 생성
            ProcessStartInfo startInfo = new ProcessStartInfo {
                FileName = @"C:\Users\kdt99\Desktop\analysis_paris\venv\Scripts\python.exe",
                Arguments = $"{scriptPath} {parameters}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            Console.WriteLine("startInfo ready");

            // Process 실행
            using (Process process = new Process { StartInfo = startInfo }) {
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                // 프로세스 종료 대기
                process.WaitForExit();

                if (!string.IsNullOrEmpty(error))
                    throw new Exception($"Error occurred: {error}");

                // Python script 실행 결과 반환
                return output;
            }
        }
    }

    // Concrete Product (구체적인 제품) 클래스
    public class EiffelButton : IButton {
        public override string RunScript() {
            //MessageBox.Show("입력한 검색 키워드를 바탕으로 실행합니다.");
            //var testPara = "get_paris_list";
            //string scriptResult = RunPythonScript(scriptPath, testPara);

            //List<Paris> ret = JSONConverter.JSONConverterParis()
            return "";
        }
    }

    public class StoreButton : IButton {
        public override string RunScript() {
            //MessageBox.Show("입력한 검색 키워드를 바탕으로 실행합니다.");

            return "";
        }
    }

    public class PinButton : IButton {
        public override string RunScript() {
            //MessageBox.Show("입력한 좌표를 바탕으로 실행합니다.");
            return "";
        }
    }

    // ========================== Factory class
    // Product (제품) 인터페이스
    //public interface Trigger {
    //    void RunScript();
    //}

    // 버튼 타입 열거형
    public enum ButtonType {
        Eiffel,
        Store,
        Pin
    }

    // Creator (생성자) 클래스 (팩토리 메서드를 정의하는 클래스)
    public class ButtonFactory {
        // 팩토리 메서드: 클라이언트가 요청한 종류의 버튼을 생성하여 반환합니다.
        public static IButton CreateButton(ButtonType type) {
            switch (type) {
                case ButtonType.Eiffel:
                    return new EiffelButton();
                case ButtonType.Store:
                    return new StoreButton();
                case ButtonType.Pin:
                    return new PinButton();
                default:
                    throw new ArgumentException("Type Error");
            }
        }
    }

    // UseButton 클래스를 통해 팩토리로 생성한 Product를 실행, 결과를 반환한다.
    public class UseButton {
        public static string GetScriptResult(ButtonType type, string searchKeyword) {
            IButton button = ButtonFactory.CreateButton(type);
            string ret = button.RunScript();
            return ret;
        }

    }

}