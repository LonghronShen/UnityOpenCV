﻿/*
 * (C) 2008-2012 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp
{
    public static partial class Cv
    {
        #region Undistort2
#if LANG_JP
        /// <summary>
        /// 半径方向や円周方向のレンズ歪みを補正するために画像を変換する．
        /// </summary>
        /// <param name="src">入力画像（歪みあり）</param>
        /// <param name="dst">出力画像（補正済み）</param>
        /// <param name="intrinsic_matrix">カメラ内部行列 (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortion_coeffs">歪み係数ベクトル． 4x1 または 1x4 [k1, k2, p1, p2]. </param>
#else
        /// <summary>
        /// Transforms image to compensate lens distortion.
        /// </summary>
        /// <param name="src">The input (distorted) image. </param>
        /// <param name="dst">The output (corrected) image. </param>
        /// <param name="intrinsic_matrix">The camera matrix (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortion_coeffs">The vector of distortion coefficients, 4x1 or 1x4 [k1, k2, p1, p2]. </param>
#endif
        public static void Undistort2(CvArr src, CvArr dst, CvMat intrinsic_matrix, CvMat distortion_coeffs)
        {
            Undistort2(src, dst, intrinsic_matrix, distortion_coeffs, null);
        }
#if LANG_JP
        /// <summary>
        /// 半径方向や円周方向のレンズ歪みを補正するために画像を変換する．
        /// </summary>
        /// <param name="src">入力画像（歪みあり）</param>
        /// <param name="dst">出力画像（補正済み）</param>
        /// <param name="intrinsic_matrix">カメラ内部行列 (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortion_coeffs">歪み係数ベクトル． 4x1 または 1x4 [k1, k2, p1, p2]. </param>
        /// <param name="new_camera_matrix"></param>
#else
        /// <summary>
        /// Transforms image to compensate lens distortion.
        /// </summary>
        /// <param name="src">The input (distorted) image. </param>
        /// <param name="dst">The output (corrected) image. </param>
        /// <param name="intrinsic_matrix">The camera matrix (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortion_coeffs">The vector of distortion coefficients, 4x1 or 1x4 [k1, k2, p1, p2]. </param>
        /// <param name="new_camera_matrix"></param>
#endif
        public static void Undistort2(CvArr src, CvArr dst, CvMat intrinsic_matrix, CvMat distortion_coeffs, CvMat new_camera_matrix)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (intrinsic_matrix == null)
                throw new ArgumentNullException("intrinsic_matrix");
            if (distortion_coeffs == null)
                throw new ArgumentNullException("distortion_coeffs");

            IntPtr new_camera_matrix_ptr = (new_camera_matrix == null) ? IntPtr.Zero : new_camera_matrix.CvPtr;
            CvInvoke.cvUndistort2(src.CvPtr, dst.CvPtr, intrinsic_matrix.CvPtr, distortion_coeffs.CvPtr, new_camera_matrix_ptr);
        }
        #endregion
        #region UndistortPoints
#if LANG_JP
        /// <summary>
        /// 観測された点座標から理想的な点座標を計算する
        /// </summary>
        /// <param name="src">カメラで観測された点座標の集合．</param>
        /// <param name="dst">歪み補正後に逆透視投影を行った理想的な点座標.</param>
        /// <param name="camera_matrix">カメラ行列 A=[fx 0 cx; 0 fy cy; 0 0 1] </param>
        /// <param name="dist_coeffs">歪み係数のベクトル，4x1, 1x4, 5x1, 1x5．</param>
        /// <param name="R">オブジェクト空間での平行化変換（3x3 行列）． cvStereoRectify で計算された値， R1 あるいは R2 が渡される．このパラメータが null の場合，単位行列が用いられる．</param>
        /// <param name="P">新しいカメラ行列（3x3），あるいは，新しい投影行列（3x4）． cvStereoRectify  で計算された値， P1 あるいは P2  が渡される． このパラメータが null の場合，単位行列が用いられる． </param>
#else
        /// <summary>
        /// Computes the ideal point coordinates from the observed point coordinates
        /// </summary>
        /// <param name="src">The observed point coordinates. </param>
        /// <param name="dst">The ideal point coordinates, after undistortion and reverse perspective transformation. </param>
        /// <param name="camera_matrix">The camera matrix A=[fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="dist_coeffs">The vector of distortion coefficients, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="R">The rectification transformation in object space (3x3 matrix). R1 or R2, computed by cvStereoRectify can be passed here. If the parameter is null, the identity matrix is used. </param>
        /// <param name="P">The new camera matrix (3x3) or the new projection matrix (3x4). P1 or P2, computed by cvStereoRectify can be passed here. If the parameter is null, the identity matrix is used. </param>
#endif
        public static void UndistortPoints(CvMat src, CvMat dst, CvMat camera_matrix, CvMat dist_coeffs, CvMat R, CvMat P)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (camera_matrix == null)
                throw new ArgumentNullException("camera_matrix");
            if (dist_coeffs == null)
                throw new ArgumentNullException("dist_coeffs");

            IntPtr R_ptr = (R == null) ? IntPtr.Zero : R.CvPtr;
            IntPtr P_ptr = (P == null) ? IntPtr.Zero : P.CvPtr;

            CvInvoke.cvUndistortPoints(src.CvPtr, dst.CvPtr, camera_matrix.CvPtr, dist_coeffs.CvPtr, R_ptr, P_ptr);
        }
        #endregion
        #region UnregisterType
#if LANG_JP
        /// <summary>
        /// 型の登録を取り消す
        /// </summary>
        /// <param name="type_name">登録を取り消す型の名前</param>
#else
        /// <summary>
        /// Unregisters the type
        /// </summary>
        /// <param name="type_name">Name of the unregistered type. </param>
#endif
        public static void UnregisterType(string type_name)
        {
            if (string.IsNullOrEmpty(type_name))
            {
                throw new ArgumentNullException("type_name");
            }
            CvInvoke.cvUnregisterType(type_name);
        }
        #endregion
        #region UpdateMotionHistory
#if LANG_JP
        /// <summary>
        /// 動くシルエットを用いてモーション履歴画像を更新する
        /// </summary>
        /// <param name="silhouette">モーションが発生した場所が 0 以外のピクセル値をもつシルエットマスク．</param>
        /// <param name="mhi">関数によって更新される，モーション履歴画像（シングルチャンネル，32 ビット浮動小数点型）．</param>
        /// <param name="timestamp">ミリ秒単位，あるはその他の単位で表される現在時間．</param>
        /// <param name="duration">timestamp と同じ時間単位で表される，モーション軌跡の最大保持時間． </param>
#else
        /// <summary>
        /// Updates motion history image by moving silhouette
        /// </summary>
        /// <param name="silhouette">Silhouette mask that has non-zero pixels where the motion occurs. </param>
        /// <param name="mhi">Motion history image, that is updated by the function (single-channel, 32-bit floating-point)  </param>
        /// <param name="timestamp">Current time in milliseconds or other units.  </param>
        /// <param name="duration">Maximal duration of motion track in the same units as timestamp.  </param>
#endif
        public static void UpdateMotionHistory(CvArr silhouette, CvArr mhi, double timestamp, double duration)
        {
            if (silhouette == null)
                throw new ArgumentNullException("silhouette");
            if (mhi == null)
                throw new ArgumentNullException("mhi");
            CvInvoke.cvUpdateMotionHistory(silhouette.CvPtr, mhi.CvPtr, timestamp, duration);
        }
        #endregion
        #region UseOptimized
#if LANG_JP
        /// <summary>
        /// 最適化モード／非最適化モードを切り替える
        /// </summary>
        /// <param name="on_off">trueのとき最適化，falseのとき非最適化．</param>
        /// <returns>ロードされた最適化関数の数</returns>
#else
        /// <summary>
        /// Switches between optimized/non-optimized modes
        /// </summary>
        /// <param name="on_off">Use optimized (true) or not (false). </param>
        /// <returns>the number of optimized functions loaded</returns>
#endif
        public static int UseOptimized(bool on_off)
        {
            return CvInvoke.cvUseOptimized(on_off);
        }
        #endregion
    }
}