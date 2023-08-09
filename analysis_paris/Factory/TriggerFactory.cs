using System;
using System.Diagnostics;

namespace analysis_paris.Factory {
    // ========================== Product 관련 클래스
    #region Product
    // IButton 추상 클래스
    public abstract class ITrigger {
        // 파이썬 스크립트 실행 메소드
        public string scriptPath = @"C:\Users\kdt99\source\repos\analysis_paris\analysis_paris\bin\Debug\python_controller.py";

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

            // Process 실행
            using (Process process = new Process { StartInfo = startInfo }) {
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                // 프로세스 종료 대기
                process.WaitForExit();

                if (!string.IsNullOrEmpty(error)) {
                    Console.WriteLine(error);
                    throw new Exception($"Error occurred: {error}");
                }

                // Python script 실행 결과 반환
                return output;
            }
        }

        // 팩토리에서 override 할 메소드
        public abstract string RunScript(string parameters);
    }

    // Concrete Product (구체적인 제품) 클래스
    public class AllParis : ITrigger {  // 파리바게뜨 전체 매장 검색
        public override string RunScript(string parameters) {
            string scriptParameter = "get_all_paris_list";
            string scriptResult = RunPythonScript(scriptPath, scriptParameter);

            return scriptResult;
        }
    }

    public class AllSellingArea : ITrigger {    // 전체 매물 검색
        public override string RunScript(string parameters) {
            string scriptParameter = "get_all_selling_area_list";
            string scriptResult = RunPythonScript(scriptPath, scriptParameter);

            return scriptResult;
        }
    }

    public class ParisById : ITrigger { // 특정 Id로 파리바게뜨 매장 검색
        public override string RunScript(string parameters) {
            string scriptParameter = $"get_paris_by_id {parameters}";
            string scriptResult = RunPythonScript(scriptPath, scriptParameter);

            return scriptResult;
        }
    }

    public class LocationInfo : ITrigger { // 좌표로 주변 정보?????  검색
        public override string RunScript(string parameters) {
            string scriptParameter = $"get_location_information {parameters}";
            string scriptResult = RunPythonScript(scriptPath, scriptParameter);

            return scriptResult;
        }
    }

    public class SellingAreaAddress : ITrigger { // 주소로 매물 검색
        public override string RunScript(string parameters) {
            string scriptParameter = $"find_selling_area_by_address {parameters}";
            string scriptResult = RunPythonScript(scriptPath, scriptParameter);

            return scriptResult;
        }
    }

    public class StoreReport : ITrigger { // 리포트 검색
        public override string RunScript(string parameters) {
            string scriptParameter = $"get_sale_area_report {parameters}";
            string scriptResult = RunPythonScript(scriptPath, scriptParameter);

            Console.WriteLine(scriptResult);

            return scriptResult;
        }
    }
    #endregion

    // ========================== Factory class
    // Product (제품) 인터페이스
    //public interface Trigger {
    //    void RunScript();
    //}

    // 버튼 타입 열거형
    public enum TriggerType {
        AllParis,
        AllSellingArea,
        ParisById,
        LocationInfo,
        SellingAreaAddress,
        StoreReport
    }

    // Creator (생성자) 클래스 (팩토리 메서드를 정의하는 클래스)
    public class TriggerFactory {
        // 팩토리 메서드: 클라이언트가 요청한 종류의 버튼을 생성하여 반환합니다.
        public static ITrigger SetTrigger(TriggerType type) {
            switch (type) {
                case TriggerType.AllParis:
                    return new AllParis();
                case TriggerType.AllSellingArea:
                    return new AllSellingArea();
                case TriggerType.ParisById:
                    return new ParisById();
                case TriggerType.LocationInfo:
                    return new LocationInfo();
                case TriggerType.SellingAreaAddress:
                    return new SellingAreaAddress();
                case TriggerType.StoreReport:
                    return new StoreReport();
                default:
                    throw new ArgumentException("Type Error");
            }
        }
    }

    // Percussion 클래스를 통해 팩토리로 생성한 Product를 실행, 결과를 반환한다.
    public class Percussion {
        public static string GetScriptResult(TriggerType type, string otherParameter) {
            ITrigger trigger = TriggerFactory.SetTrigger(type);
            string scriptResult = trigger.RunScript(otherParameter);
            return scriptResult;
        }

    }

}