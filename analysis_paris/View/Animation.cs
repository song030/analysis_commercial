using System;
using System.Windows.Forms;

namespace analysis_paris.View {
    internal class Animaion {
        // /////////////////////////////////////////////////// 후작업 ////////////////////////////////////////////////////////////
        /// <summary>
        /// 스플리터 슬라이드 애니메이션
        /// </summary>
        /// <param name="splitter">대상 스플리터</param>
        /// <param name="isTargetPanel1">슬라이드할 패널이 1인지 여부</param>
        /// <param name="stepSize">슬라이드 간격 : 클수록 빨라짐</param>
        public static void SplitterAnimationCollapse(SplitContainer targetSplit, bool isTargetPanel1, int stepSize) {
            try {
                int originalDistance = Convert.ToInt32(targetSplit.Tag); // 태그에 저장한 스플리터 기준 위치
                int currentDistance = targetSplit.SplitterDistance; // 현재 스플리터 위치

                if (isTargetPanel1) { // panel1 토글

                    if (targetSplit.Panel1Collapsed) { // panel1 펼치기
                        targetSplit.Panel1Collapsed = false;
                        while (true) {
                            currentDistance += stepSize;

                            if (currentDistance >= originalDistance) {
                                targetSplit.SplitterDistance = originalDistance;
                                break;
                            }

                            targetSplit.SplitterDistance = currentDistance;
                            Application.DoEvents();
                        }
                    }
                    else { // panel1 접기
                        while (true) {
                            currentDistance -= stepSize;

                            if (currentDistance <= 0) {
                                targetSplit.Panel1Collapsed = true;
                                break;
                            }

                            targetSplit.SplitterDistance = currentDistance;
                            Application.DoEvents();
                        }
                    }
                }
                else { // panel2 토글

                    if (targetSplit.Panel2Collapsed) { // panel2 펼치기
                        targetSplit.Panel2Collapsed = false;

                        Console.WriteLine(targetSplit.Orientation.CompareTo(Orientation.Vertical));

                        if (targetSplit.Orientation == Orientation.Vertical) {
                            Console.WriteLine("세로 스플리터");
                            targetSplit.SplitterDistance = targetSplit.Height;
                        }
                        else {
                            targetSplit.SplitterDistance = targetSplit.Width;
                        }

                        while (true) {
                            currentDistance -= stepSize;

                            if (currentDistance <= originalDistance) {
                                targetSplit.SplitterDistance = originalDistance;
                                break;
                            }

                            targetSplit.SplitterDistance = currentDistance;
                            Application.DoEvents();
                        }
                    }
                    else { // panel2 접기
                        while (true) {
                            currentDistance += stepSize;

                            if (currentDistance >= targetSplit.Width) {
                                targetSplit.Panel2Collapsed = true;
                            }

                            targetSplit.SplitterDistance = currentDistance;
                            Application.DoEvents();
                        }
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
