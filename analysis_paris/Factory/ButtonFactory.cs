using System;

namespace MarkeAnalysis.Factory {
    // Product (제품) 인터페이스
    public interface IButton {
        void Render();
    }

    // Concrete Product (구체적인 제품) 클래스
    public class NormalButton : IButton {
        public void Render() {
            //MessageBox.Show("일반 버튼을 렌더링합니다.");
        }
    }

    public class SpecialButton : IButton {
        public void Render() {
            //MessageBox.Show("특별한 버튼을 렌더링합니다.");
        }
    }

    // Creator (생성자) 클래스 (팩토리 메서드를 정의하는 클래스)
    public class ButtonFactory {
        // 팩토리 메서드: 클라이언트가 요청한 종류의 버튼을 생성하여 반환합니다.
        public static IButton CreateButton(ButtonType type) {
            switch (type) {
                case ButtonType.Normal:
                    return new NormalButton();
                case ButtonType.Special:
                    return new SpecialButton();
                default:
                    throw new ArgumentException("지원되지 않는 버튼 타입입니다.");
            }
        }
    }

    // 버튼 타입 열거형
    public enum ButtonType {
        Normal,
        Special
    }
}