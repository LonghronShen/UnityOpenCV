/*
 * (C) 2008-2012 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp
{
    public static partial class Cv
    {
        #region EigenDecomposite
#if LANG_JP
        /// <summary>
        /// 入力オブジェクトのすべての分解係数を計算する. (ioFlags = CV_EIGOBJ_NO_CALLBACK)
        /// </summary>
        /// <param name="obj">入力オブジェクト.</param>
        /// <param name="eigInput">IplImage 型の入力オブジェクトの配列.</param>
        /// <param name="avg">平均オブジェクト.</param>
        /// <param name="coeffs">計算された係数; 出力パラメータ.</param>
#else
        /// <summary>
        /// Calculates all of the decomposition coefficients for an input object. (ioFlags = CV_EIGOBJ_NO_CALLBACK)
        /// </summary>
        /// <param name="obj">Input object.</param>
        /// <param name="eigInput">Pointer to the array of IplImage input objects.</param>
        /// <param name="avg">Averaged object.</param>
        /// <param name="coeffs">Calculated coefficients; an output parameter.</param>
#endif
        public static void EigenDecomposite(IplImage obj, IplImage[] eigInput, IplImage avg, float[] coeffs)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            if (eigInput == null)
                throw new ArgumentNullException("eigInput");
            if (eigInput.Length == 0)
                throw new ArgumentException("", "eigInput");
            if (avg == null)
                throw new ArgumentNullException("avg");

            int eigenvec_count = eigInput.Length;

            IntPtr[] eigInputPtr = new IntPtr[eigInput.Length];
            for (int i = 0; i < eigInput.Length; i++)
            {
                eigInputPtr[i] = eigInput[i].CvPtr;
            }

            using (ScopedGCHandle eigInputHandle = ScopedGCHandle.Alloc(eigInputPtr, GCHandleType.Pinned))
            {
                CvInvoke.cvEigenDecomposite(obj.CvPtr, eigenvec_count, eigInputHandle.AddrOfPinnedObject(), EigenObjectsIOFlag.NoCallback, IntPtr.Zero, avg.CvPtr, coeffs);
            }
        }
#if LANG_JP
        /// <summary>
        /// 入力オブジェクトのすべての分解係数を計算する.
        /// </summary>
        /// <param name="obj">入力オブジェクト</param>
        /// <param name="eigenvec_count">固有オブジェクトの個数.</param>
        /// <param name="eigInput">読み込みコールバック関数.</param>
        /// <param name="ioFlags">入出力フラグ.</param>
        /// <param name="userData">コールバック関数に必要なすべてのデータを含む構造体へのポインタ.</param>
        /// <param name="avg">平均オブジェクト.</param>
        /// <param name="coeffs">計算された係数; 出力パラメータ.</param>
#else
        /// <summary>
        /// Calculates all of the decomposition coefficients for an input object.
        /// </summary>
        /// <param name="obj">Input object.</param>
        /// <param name="eigenvec_count">Number of eigen objects.</param>
        /// <param name="eigInput">ointer to the read callback function.</param>
        /// <param name="ioFlags">Input/output flags.</param>
        /// <param name="userData">Pointer to the structure that contains all of the necessary data for the callback functions.</param>
        /// <param name="avg">Averaged object.</param>
        /// <param name="coeffs">Calculated coefficients; an output parameter.</param>
#endif
        public static void EigenDecomposite(IplImage obj, int eigenvec_count, CvCallback eigInput, EigenObjectsIOFlag ioFlags, IntPtr userData, IplImage avg, float[] coeffs)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            if (avg == null)
                throw new ArgumentNullException("avg");

            using (ScopedGCHandle eigInputhandle = ScopedGCHandle.Alloc(eigInput, GCHandleType.Normal))
            {
                CvInvoke.cvEigenDecomposite(obj.CvPtr, eigenvec_count, eigInput, ioFlags, userData, avg.CvPtr, coeffs);
            }
        }
        #endregion
        #region EigenProjection
#if LANG_JP
        /// <summary>
        /// オブジェクトの固有部分空間への投影を計算する (ioFlags = CV_EIGOBJ_NO_CALLBACK)
        /// </summary>
        /// <param name="input_vecs">IplImage 型の入力オブジェクトの配列</param>
        /// <param name="eigenvec_count">固有ベクトルの個数． </param>
        /// <param name="coeffs">事前に計算された分解係数． </param>
        /// <param name="avg">cvCalcEigenObjects  によって計算された平均ベクトル．</param>
        /// <param name="proj">固有部分空間への投影．</param>
#else
        /// <summary>
        /// Calculates the object projection into the eigen sub-space. (ioFlags = CV_EIGOBJ_NO_CALLBACK)
        /// </summary>
        /// <param name="input_vecs">Pointer to an array of IplImage input objects.</param>
        /// <param name="eigenvec_count">Number of eigenvectors.</param>
        /// <param name="coeffs">Previously calculated decomposition coefficients.</param>
        /// <param name="avg">Average vector</param>
        /// <param name="proj">Projection to the eigen sub-space.</param>
#endif
        public static void EigenProjection(IplImage[] input_vecs, int eigenvec_count, float[] coeffs, IplImage avg, IplImage proj)
        {
            if (input_vecs == null)
                throw new ArgumentNullException("input_vecs");
            if (input_vecs.Length == 0)
                throw new ArgumentException("", "input_vecs");
            if (avg == null)
                throw new ArgumentNullException("avg");
            if (proj == null)
                throw new ArgumentNullException("proj");

            IntPtr[] inputVecsPtr = new IntPtr[input_vecs.Length];
            for (int i = 0; i < input_vecs.Length; i++)
            {
                inputVecsPtr[i] = input_vecs[i].CvPtr;
            }

            using (ScopedGCHandle inputVecsHandle = ScopedGCHandle.Alloc(inputVecsPtr, GCHandleType.Pinned))
            {
                CvInvoke.cvEigenProjection(inputVecsHandle.AddrOfPinnedObject(), eigenvec_count, EigenObjectsIOFlag.NoCallback, IntPtr.Zero, coeffs, avg.CvPtr, proj.CvPtr);
            }
        }
#if LANG_JP
        /// <summary>
        /// オブジェクトの固有部分空間への投影を計算する
        /// </summary>
        /// <param name="input_vecs">コールバック関数</param>
        /// <param name="eigenvec_count">固有ベクトルの個数． </param>
        /// <param name="io_flags">入出力フラグ.</param>
        /// <param name="userdata">コールバック関数に必要なすべてのデータを含む構造体へのポインタ．</param>
        /// <param name="coeffs">事前に計算された分解係数． </param>
        /// <param name="avg">cvCalcEigenObjects  によって計算された平均ベクトル．</param>
        /// <param name="proj">固有部分空間への投影．</param>
#else
        /// <summary>
        /// Calculates the object projection into the eigen sub-space.
        /// </summary>
        /// <param name="input_vecs">Pointer to to a callback function, depending on io_flags.</param>
        /// <param name="eigenvec_count">Number of eigenvectors.</param>
        /// <param name="io_flags">Input/output flags</param>
        /// <param name="userdata">Pointer to the structure that contains all of the necessary data for the callback functions.</param>
        /// <param name="coeffs">Previously calculated decomposition coefficients.</param>
        /// <param name="avg">Average vector</param>
        /// <param name="proj">Projection to the eigen sub-space.</param>
#endif
        public static void EigenProjection(CvCallback input_vecs, int eigenvec_count, EigenObjectsIOFlag io_flags, IntPtr userdata, float[] coeffs, IplImage avg, IplImage proj)
        {
            if (avg == null)
                throw new ArgumentNullException("avg");
            if (proj == null)
                throw new ArgumentNullException("proj");

            using (ScopedGCHandle inputVecsHandle = ScopedGCHandle.Alloc(input_vecs, GCHandleType.Normal))
            {
                CvInvoke.cvEigenProjection(input_vecs, eigenvec_count, io_flags, userdata, coeffs, avg.CvPtr, proj.CvPtr);
            }
        }
        #endregion
        #region EigenVV
#if LANG_JP
        /// <summary>
        /// 対称行列の固有値と固有ベクトルを計算する
        /// </summary>
        /// <param name="mat">入力対称正方行列．処理中に変更される．</param>
        /// <param name="evects">固有ベクトルの出力行列．連続した行として保存される． </param>
        /// <param name="evals">固有値ベクトルの出力ベクトル．降順に保存される（もちろん固有値と固有ベクトルの順番は一致する）．</param>
#else
        /// <summary>
        /// Computes eigenvalues and eigenvectors of symmetric matrix
        /// </summary>
        /// <param name="mat">The input symmetric square matrix. It is modified during the processing. </param>
        /// <param name="evects">The output matrix of eigenvectors, stored as a subsequent rows. </param>
        /// <param name="evals">The output vector of eigenvalues, stored in the descending order (order of eigenvalues and eigenvectors is synchronized, of course). </param>
#endif
        public static void EigenVV(CvArr mat, CvArr evects, CvArr evals)
        {
            EigenVV(mat, evects, evals, 0, 0, 0);
        }
#if LANG_JP
        /// <summary>
        /// 対称行列の固有値と固有ベクトルを計算する
        /// </summary>
        /// <param name="mat">入力対称正方行列．処理中に変更される．</param>
        /// <param name="evects">固有ベクトルの出力行列．連続した行として保存される． </param>
        /// <param name="evals">固有値ベクトルの出力ベクトル．降順に保存される（もちろん固有値と固有ベクトルの順番は一致する）．</param>
        /// <param name="eps">対角化の精度（一般的に，DBL_EPSILON=≈10^-15 で十分である）</param>
#else
        /// <summary>
        /// Computes eigenvalues and eigenvectors of symmetric matrix
        /// </summary>
        /// <param name="mat">The input symmetric square matrix. It is modified during the processing. </param>
        /// <param name="evects">The output matrix of eigenvectors, stored as a subsequent rows. </param>
        /// <param name="evals">The output vector of eigenvalues, stored in the descending order (order of eigenvalues and eigenvectors is synchronized, of course). </param>
        /// <param name="eps">Accuracy of diagonalization (typically, DBL_EPSILON=≈10-15 is enough). </param>
#endif
        public static void EigenVV(CvArr mat, CvArr evects, CvArr evals, double eps)
        {
            EigenVV(mat, evects, evals, eps, 0, 0);
        }
#if LANG_JP
        /// <summary>
        /// 対称行列の固有値と固有ベクトルを計算する
        /// </summary>
        /// <param name="mat">入力対称正方行列．処理中に変更される．</param>
        /// <param name="evects">固有ベクトルの出力行列．連続した行として保存される． </param>
        /// <param name="evals">固有値ベクトルの出力ベクトル．降順に保存される（もちろん固有値と固有ベクトルの順番は一致する）．</param>
        /// <param name="eps">対角化の精度（一般的に，DBL_EPSILON=≈10^-15 で十分である）</param>
        /// <param name="lowindex">求める最大の固有値/固有ベクトルのインデックス</param>
#else
        /// <summary>
        /// Computes eigenvalues and eigenvectors of symmetric matrix
        /// </summary>
        /// <param name="mat">The input symmetric square matrix. It is modified during the processing. </param>
        /// <param name="evects">The output matrix of eigenvectors, stored as a subsequent rows. </param>
        /// <param name="evals">The output vector of eigenvalues, stored in the descending order (order of eigenvalues and eigenvectors is synchronized, of course). </param>
        /// <param name="eps">Accuracy of diagonalization (typically, DBL_EPSILON=≈10-15 is enough). </param>
        /// <param name="lowindex">Optional index of largest eigenvalue/-vector to calculate.</param>
#endif
        public static void EigenVV(CvArr mat, CvArr evects, CvArr evals, double eps, int lowindex)
        {
            EigenVV(mat, evects, evals, eps, lowindex, 0);
        }
#if LANG_JP
        /// <summary>
        /// 対称行列の固有値と固有ベクトルを計算する
        /// </summary>
        /// <param name="mat">入力対称正方行列．処理中に変更される．</param>
        /// <param name="evects">固有ベクトルの出力行列．連続した行として保存される． </param>
        /// <param name="evals">固有値ベクトルの出力ベクトル．降順に保存される（もちろん固有値と固有ベクトルの順番は一致する）．</param>
        /// <param name="eps">対角化の精度（一般的に，DBL_EPSILON=≈10^-15 で十分である）</param>
        /// <param name="lowindex">求める最大の固有値/固有ベクトルのインデックス</param>
        /// <param name="highindex">求める最小の固有値/固有ベクトルのインデックス</param>
#else
        /// <summary>
        /// Computes eigenvalues and eigenvectors of symmetric matrix
        /// </summary>
        /// <param name="mat">The input symmetric square matrix. It is modified during the processing. </param>
        /// <param name="evects">The output matrix of eigenvectors, stored as a subsequent rows. </param>
        /// <param name="evals">The output vector of eigenvalues, stored in the descending order (order of eigenvalues and eigenvectors is synchronized, of course). </param>
        /// <param name="eps">Accuracy of diagonalization (typically, DBL_EPSILON=≈10-15 is enough). </param>
        /// <param name="lowindex">Optional index of largest eigenvalue/-vector to calculate.</param>
        /// <param name="highindex">Optional index of smallest eigenvalue/-vector to calculate.</param>
#endif
        public static void EigenVV(CvArr mat, CvArr evects, CvArr evals, double eps, int lowindex, int highindex)
        {
            if (mat == null)
                throw new ArgumentNullException("mat");
            if (evects == null)
                throw new ArgumentNullException("evects");
            if (evals == null)
                throw new ArgumentNullException("evals");
            CvInvoke.cvEigenVV(mat.CvPtr, evects.CvPtr, evals.CvPtr, eps, lowindex, highindex);
        }
        #endregion
        #region Ellipse
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，楕円弧，もしくは塗りつぶされた扇形の楕円を描画する
        /// </summary>
        /// <param name="img">楕円が描画される画像</param>
        /// <param name="center">楕円の中心</param>
        /// <param name="axes">楕円の軸の長さ</param>
        /// <param name="angle">回転角度</param>
        /// <param name="start_angle">楕円弧の開始角度</param>
        /// <param name="end_angle">楕円弧の終了角度</param>
        /// <param name="color">楕円の色</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="center">Center of the ellipse. </param>
        /// <param name="axes">Length of the ellipse axes. </param>
        /// <param name="angle">Rotation angle. </param>
        /// <param name="start_angle">Starting angle of the elliptic arc. </param>
        /// <param name="end_angle">Ending angle of the elliptic arc. </param>
        /// <param name="color">Ellipse color. </param>
#endif
        public static void Ellipse(CvArr img, CvPoint center, CvSize axes, double angle, double start_angle, double end_angle, CvScalar color)
        {
            Ellipse(img, center, axes, angle, start_angle, end_angle, color, 1, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，楕円弧，もしくは塗りつぶされた扇形の楕円を描画する
        /// </summary>
        /// <param name="img">楕円が描画される画像</param>
        /// <param name="center">楕円の中心</param>
        /// <param name="axes">楕円の軸の長さ</param>
        /// <param name="angle">回転角度</param>
        /// <param name="start_angle">楕円弧の開始角度</param>
        /// <param name="end_angle">楕円弧の終了角度</param>
        /// <param name="color">楕円の色</param>
        /// <param name="thickness">楕円弧の線の幅</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="center">Center of the ellipse. </param>
        /// <param name="axes">Length of the ellipse axes. </param>
        /// <param name="angle">Rotation angle. </param>
        /// <param name="start_angle">Starting angle of the elliptic arc. </param>
        /// <param name="end_angle">Ending angle of the elliptic arc. </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse arc. </param>
#endif
        public static void Ellipse(CvArr img, CvPoint center, CvSize axes, double angle, double start_angle, double end_angle, CvScalar color, int thickness)
        {
            Ellipse(img, center, axes, angle, start_angle, end_angle, color, thickness, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，楕円弧，もしくは塗りつぶされた扇形の楕円を描画する
        /// </summary>
        /// <param name="img">楕円が描画される画像</param>
        /// <param name="center">楕円の中心</param>
        /// <param name="axes">楕円の軸の長さ</param>
        /// <param name="angle">回転角度</param>
        /// <param name="start_angle">楕円弧の開始角度</param>
        /// <param name="end_angle">楕円弧の終了角度</param>
        /// <param name="color">楕円の色</param>
        /// <param name="thickness">楕円弧の線の幅</param>
        /// <param name="line_type">楕円弧の線の種類</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="center">Center of the ellipse. </param>
        /// <param name="axes">Length of the ellipse axes. </param>
        /// <param name="angle">Rotation angle. </param>
        /// <param name="start_angle">Starting angle of the elliptic arc. </param>
        /// <param name="end_angle">Ending angle of the elliptic arc. </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse arc. </param>
        /// <param name="line_type">Type of the ellipse boundary.</param>
#endif
        public static void Ellipse(CvArr img, CvPoint center, CvSize axes, double angle, double start_angle, double end_angle, CvScalar color, int thickness, LineType line_type)
        {
            Ellipse(img, center, axes, angle, start_angle, end_angle, color, thickness, line_type, 0);
        }
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，楕円弧，もしくは塗りつぶされた扇形の楕円を描画する
        /// </summary>
        /// <param name="img">楕円が描画される画像</param>
        /// <param name="center">楕円の中心</param>
        /// <param name="axes">楕円の軸の長さ</param>
        /// <param name="angle">回転角度</param>
        /// <param name="start_angle">楕円弧の開始角度</param>
        /// <param name="end_angle">楕円弧の終了角度</param>
        /// <param name="color">楕円の色</param>
        /// <param name="thickness">楕円弧の線の幅</param>
        /// <param name="line_type">楕円弧の線の種類</param>
        /// <param name="shift">中心座標と軸の長さの小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="center">Center of the ellipse. </param>
        /// <param name="axes">Length of the ellipse axes. </param>
        /// <param name="angle">Rotation angle. </param>
        /// <param name="start_angle">Starting angle of the elliptic arc. </param>
        /// <param name="end_angle">Ending angle of the elliptic arc. </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse arc. </param>
        /// <param name="line_type">Type of the ellipse boundary.</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and axes' values. </param>
#endif
        public static void Ellipse(CvArr img, CvPoint center, CvSize axes, double angle, double start_angle, double end_angle, CvScalar color, int thickness, LineType line_type, int shift)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            CvInvoke.cvEllipse(img.CvPtr, center, axes, angle, start_angle, end_angle, color, thickness, line_type, shift);
        }
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，楕円弧，もしくは塗りつぶされた扇形の楕円を描画する
        /// </summary>
        /// <param name="img">楕円が描画される画像</param>
        /// <param name="center">楕円の中心</param>
        /// <param name="axes">楕円の軸の長さ</param>
        /// <param name="angle">回転角度</param>
        /// <param name="start_angle">楕円弧の開始角度</param>
        /// <param name="end_angle">楕円弧の終了角度</param>
        /// <param name="color">楕円の色</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="center">Center of the ellipse. </param>
        /// <param name="axes">Length of the ellipse axes. </param>
        /// <param name="angle">Rotation angle. </param>
        /// <param name="start_angle">Starting angle of the elliptic arc. </param>
        /// <param name="end_angle">Ending angle of the elliptic arc. </param>
        /// <param name="color">Ellipse color. </param>
#endif
        public static void DrawEllipse(CvArr img, CvPoint center, CvSize axes, double angle, double start_angle, double end_angle, CvScalar color)
        {
            Ellipse(img, center, axes, angle, start_angle, end_angle, color, 1, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，楕円弧，もしくは塗りつぶされた扇形の楕円を描画する
        /// </summary>
        /// <param name="img">楕円が描画される画像</param>
        /// <param name="center">楕円の中心</param>
        /// <param name="axes">楕円の軸の長さ</param>
        /// <param name="angle">回転角度</param>
        /// <param name="start_angle">楕円弧の開始角度</param>
        /// <param name="end_angle">楕円弧の終了角度</param>
        /// <param name="color">楕円の色</param>
        /// <param name="thickness">楕円弧の線の幅</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="center">Center of the ellipse. </param>
        /// <param name="axes">Length of the ellipse axes. </param>
        /// <param name="angle">Rotation angle. </param>
        /// <param name="start_angle">Starting angle of the elliptic arc. </param>
        /// <param name="end_angle">Ending angle of the elliptic arc. </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse arc. </param>
#endif
        public static void DrawEllipse(CvArr img, CvPoint center, CvSize axes, double angle, double start_angle, double end_angle, CvScalar color, int thickness)
        {
            Ellipse(img, center, axes, angle, start_angle, end_angle, color, thickness, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，楕円弧，もしくは塗りつぶされた扇形の楕円を描画する
        /// </summary>
        /// <param name="img">楕円が描画される画像</param>
        /// <param name="center">楕円の中心</param>
        /// <param name="axes">楕円の軸の長さ</param>
        /// <param name="angle">回転角度</param>
        /// <param name="start_angle">楕円弧の開始角度</param>
        /// <param name="end_angle">楕円弧の終了角度</param>
        /// <param name="color">楕円の色</param>
        /// <param name="thickness">楕円弧の線の幅</param>
        /// <param name="line_type">楕円弧の線の種類</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="center">Center of the ellipse. </param>
        /// <param name="axes">Length of the ellipse axes. </param>
        /// <param name="angle">Rotation angle. </param>
        /// <param name="start_angle">Starting angle of the elliptic arc. </param>
        /// <param name="end_angle">Ending angle of the elliptic arc. </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse arc. </param>
        /// <param name="line_type">Type of the ellipse boundary.</param>
#endif
        public static void DrawEllipse(CvArr img, CvPoint center, CvSize axes, double angle, double start_angle, double end_angle, CvScalar color, int thickness, LineType line_type)
        {
            Ellipse(img, center, axes, angle, start_angle, end_angle, color, thickness, line_type, 0);
        }
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，楕円弧，もしくは塗りつぶされた扇形の楕円を描画する
        /// </summary>
        /// <param name="img">楕円が描画される画像</param>
        /// <param name="center">楕円の中心</param>
        /// <param name="axes">楕円の軸の長さ</param>
        /// <param name="angle">回転角度</param>
        /// <param name="start_angle">楕円弧の開始角度</param>
        /// <param name="end_angle">楕円弧の終了角度</param>
        /// <param name="color">楕円の色</param>
        /// <param name="thickness">楕円弧の線の幅</param>
        /// <param name="line_type">楕円弧の線の種類</param>
        /// <param name="shift">中心座標と軸の長さの小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="center">Center of the ellipse. </param>
        /// <param name="axes">Length of the ellipse axes. </param>
        /// <param name="angle">Rotation angle. </param>
        /// <param name="start_angle">Starting angle of the elliptic arc. </param>
        /// <param name="end_angle">Ending angle of the elliptic arc. </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse arc. </param>
        /// <param name="line_type">Type of the ellipse boundary.</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and axes' values. </param>
#endif
        public static void DrawEllipse(CvArr img, CvPoint center, CvSize axes, double angle, double start_angle, double end_angle, CvScalar color, int thickness, LineType line_type, int shift)
        {
            Ellipse(img, center, axes, angle, start_angle, end_angle, color, thickness, line_type, shift);
        }
        #endregion
        #region EllipseBox
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，もしくは塗りつぶされた楕円を描画する
        /// </summary>
        /// <param name="img">楕円が描かれる画像．</param>
        /// <param name="box">描画したい楕円を囲む矩形領域．</param>
        /// <param name="color">楕円の色．</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="box">The enclosing box of the ellipse drawn </param>
        /// <param name="color">Ellipse color. </param>
#endif
        public static void EllipseBox(CvArr img, CvBox2D box, CvScalar color)
        {
            EllipseBox(img, box, color, 1, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，もしくは塗りつぶされた楕円を描画する
        /// </summary>
        /// <param name="img">楕円が描かれる画像．</param>
        /// <param name="box">描画したい楕円を囲む矩形領域．</param>
        /// <param name="color">楕円の色．</param>
        /// <param name="thickness">楕円境界線の幅．</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="box">The enclosing box of the ellipse drawn </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse boundary. </param>
#endif
        public static void EllipseBox(CvArr img, CvBox2D box, CvScalar color, int thickness)
        {
            EllipseBox(img, box, color, thickness, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，もしくは塗りつぶされた楕円を描画する
        /// </summary>
        /// <param name="img">楕円が描かれる画像．</param>
        /// <param name="box">描画したい楕円を囲む矩形領域．</param>
        /// <param name="color">楕円の色．</param>
        /// <param name="thickness">楕円境界線の幅．</param>
        /// <param name="line_type">楕円境界線の種類．</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="box">The enclosing box of the ellipse drawn </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse boundary. </param>
        /// <param name="line_type">Type of the ellipse boundary</param>
#endif
        public static void EllipseBox(CvArr img, CvBox2D box, CvScalar color, int thickness, LineType line_type)
        {
            EllipseBox(img, box, color, thickness, line_type, 0);
        }
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，もしくは塗りつぶされた楕円を描画する
        /// </summary>
        /// <param name="img">楕円が描かれる画像．</param>
        /// <param name="box">描画したい楕円を囲む矩形領域．</param>
        /// <param name="color">楕円の色．</param>
        /// <param name="thickness">楕円境界線の幅．</param>
        /// <param name="line_type">楕円境界線の種類．</param>
        /// <param name="shift">矩形領域の頂点座標の小数点以下の桁を表すビット数．</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="box">The enclosing box of the ellipse drawn </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse boundary. </param>
        /// <param name="line_type">Type of the ellipse boundary</param>
        /// <param name="shift">Number of fractional bits in the box vertex coordinates. </param>
#endif
        public static void EllipseBox(CvArr img, CvBox2D box, CvScalar color, int thickness, LineType line_type, int shift)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }

            CvSize axes = new CvSize
            {
                Width = (int)Math.Round(box.Size.Height * 0.5),
                Height = (int)Math.Round(box.Size.Width * 0.5)
            };
            Ellipse(img, box.Center, axes, box.Angle, 0, 360, color, thickness, line_type, shift);
        }
        #endregion
        #region Ellipse2Poly
#if LANG_JP
        /// <summary>
        /// 楕円弧をポリラインで近似する
        /// </summary>
        /// <param name="center">弧の中心</param>
        /// <param name="axes">楕円の軸の長さ</param>
        /// <param name="angle">楕円の回転角度</param>
        /// <param name="arc_start">楕円弧の開始角度</param>
        /// <param name="arc_end">楕円弧の終了角度</param>
        /// <param name="pts">この関数で塗りつぶされる点の配列</param>
        /// <param name="delta">ポリラインの連続した頂点間の角度，近似精度．出力される点の総数は最大で ceil((end_angle - start_angle)/delta) + 1．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Approximates elliptic arc with polyline
        /// </summary>
        /// <param name="center">Center of the arc. </param>
        /// <param name="axes">Half-sizes of the arc. See cvEllipse. </param>
        /// <param name="angle">Rotation angle of the ellipse in degrees. See cvEllipse. </param>
        /// <param name="arc_start">Starting angle of the elliptic arc. </param>
        /// <param name="arc_end">Ending angle of the elliptic arc. </param>
        /// <param name="pts">The array of points, filled by the function. </param>
        /// <param name="delta">Angle between the subsequent polyline vertices, approximation accuracy. So, the total number of output points will ceil((end_angle - start_angle)/delta) + 1 at max. </param>
        /// <returns>The function cvEllipse2Poly computes vertices of the polyline that approximates the specified elliptic arc. It is used by cvEllipse. It returns the numbers of output points.</returns>
#endif
        public static int Ellipse2Poly(CvPoint center, CvSize axes, int angle, int arc_start, int arc_end, out CvPoint[] pts, int delta)
        {
            int nb_pts = (int)Math.Ceiling(((arc_end - arc_start) / (float)delta) + 1);
            pts = new CvPoint[nb_pts];
            nb_pts = CvInvoke.cvEllipse2Poly(center, axes, angle, arc_start, arc_end, pts, delta);
            //pts = new CvPoint[nb_pts];
            //Array.ConstrainedCopy(pts2, 0, pts, 0, nb_pts);       
            return nb_pts;
        }
        #endregion
        #region EncodeImage
#if LANG_JP
        /// <summary>
        /// 画像をエンコードしてバイト列として出力する
        /// </summary>
        /// <param name="ext">出力形式として定義されているファイル拡張子</param>
        /// <param name="image">入力画像</param>
        /// <param name="prms">画像フォーマット固有の各種パラメータ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Encode image and store the result as a byte vector (single-row 8uC1 matrix)
        /// </summary>
        /// <param name="ext">The file extension that defines the output format</param>
        /// <param name="image">The image to be written</param>
        /// <param name="prms">The format-specific parameters</param>
        /// <returns></returns>
#endif
        public static CvMat EncodeImage(string ext, CvArr image, int[] prms)
        {
            if (string.IsNullOrEmpty(ext))
                throw new ArgumentNullException("ext");
            if (image == null)
                throw new ArgumentNullException("image");
            IntPtr ptr = CvInvoke.cvEncodeImage(ext, image.CvPtr, prms);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvMat(ptr, true);
        }
#if LANG_JP
        /// <summary>
        /// 画像をエンコードしてバイト列として出力する
        /// </summary>
        /// <param name="ext">出力形式として定義されているファイル拡張子</param>
        /// <param name="image">入力画像</param>
        /// <param name="prms">画像フォーマット固有の各種パラメータ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Encode image and store the result as a byte vector (single-row 8uC1 matrix)
        /// </summary>
        /// <param name="ext">The file extension that defines the output format</param>
        /// <param name="image">The image to be written</param>
        /// <param name="prms">The format-specific parameters</param>
        /// <returns></returns>
#endif
        public static CvMat EncodeImage(string ext, CvArr image, params ImageEncodingParam[] prms)
        {
            List<int> p = new List<int>();
            if (prms != null)
            {
                foreach (ImageEncodingParam item in prms)
                {
                    p.Add((int)item.EncodingID);
                    p.Add(item.Value);
                }
                return EncodeImage(ext, image, p.ToArray());
            }
            else
            {
                return EncodeImage(ext, image, (int[])null);
            }
        }
        #endregion
        #region EndFindContours
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理を終了する
        /// </summary>
        /// <param name="scanner">輪郭スキャナへのポインタ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finishes scanning process
        /// </summary>
        /// <param name="scanner">Contour scanner. </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvPoint> EndFindContours(CvContourScanner scanner)
        {
            if (scanner == null)
            {
                throw new ArgumentNullException("scanner");
            }

            return scanner.EndFindContours();
        }
        #endregion
        #region EndWriteSeq
#if LANG_JP
        /// <summary>
        /// シーケンス書き込み処理を終了する
        /// </summary>
        /// <param name="writer">ライタの状態． </param>
        /// <returns>書き込まれたシーケンスへのポインタ</returns>
#else
        /// <summary>
        /// Finishes process of writing sequence
        /// </summary>
        /// <param name="writer">Writer state </param>
        /// <returns>the pointer to the written sequence.</returns>
#endif
        public static CvSeq EndWriteSeq(CvSeqWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");

            return writer.EndWriteSeq();
        }
        #endregion
        #region EndWriteStruct
#if LANG_JP
        /// <summary>
        /// ファイルストレージへの構造体の書き込みを終了する．
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
#else
        /// <summary>
        /// Ends writing a structure
        /// </summary>
        /// <param name="fs">File storage. </param>
#endif
        public static void EndWriteStruct(CvFileStorage fs)
        {
            if (fs == null)
            {
                throw new ArgumentNullException("fs");
            }
            CvInvoke.cvEndWriteStruct(fs.CvPtr);
        }
        #endregion
        #region EqualizeHist
#if LANG_JP
        /// <summary>
        /// グレースケール画像のヒストグラムを均一化する．輝度を均一化し，画像のコントラストを上げる．
        /// </summary>
        /// <param name="src">入力画像．8ビットシングルチャンネル． </param>
        /// <param name="dst">出力画像．srcと同じサイズ, 同じデータタイプ．</param>
#else
        /// <summary>
        /// Equalizes histogram of grayscale image.
        /// </summary>
        /// <param name="src">The input 8-bit single-channel image. </param>
        /// <param name="dst">The output image of the same size and the same data type as src. </param>
#endif
        public static void EqualizeHist(CvArr src, CvArr dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvEqualizeHist(src.CvPtr, dst.CvPtr);
        }
        #endregion
        #region Erode
#if LANG_JP
        /// <summary>
        /// 隣接ピクセルの形状を決定する指定された構造要素を用いて，入力画像を収縮する. 
        /// この関数はインプレースモード（src=dstである入力）をサポートする．収縮は複数回 (iterations) 繰り返すことができる．
        /// カラー画像の場合は，それぞれのチャンネルが独立に処理される． 
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
#else
        /// <summary>
        /// Erodes image by using arbitrary structuring element.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
#endif
        public static void Erode(CvArr src, CvArr dst)
        {
            Erode(src, dst, null);
        }
#if LANG_JP
        /// <summary>
        /// 隣接ピクセルの形状を決定する指定された構造要素を用いて，入力画像を収縮する. 
        /// この関数はインプレースモード（src=dstである入力）をサポートする．収縮は複数回 (iterations) 繰り返すことができる．
        /// カラー画像の場合は，それぞれのチャンネルが独立に処理される． 
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="element">収縮に用いる構造要素．nullの場合は, 3×3 の矩形形状の構造要素を用いる．</param>
#else
        /// <summary>
        /// Erodes image by using arbitrary structuring element.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="element">Structuring element used for erosion. If it is null, a 3x3 rectangular structuring element is used. </param>
#endif
        public static void Erode(CvArr src, CvArr dst, IplConvKernel element)
        {
            Erode(src, dst, element, 1);
        }
#if LANG_JP
        /// <summary>
        /// 隣接ピクセルの形状を決定する指定された構造要素を用いて，入力画像を収縮する. 
        /// この関数はインプレースモード（src=dstである入力）をサポートする．収縮は複数回 (iterations) 繰り返すことができる．
        /// カラー画像の場合は，それぞれのチャンネルが独立に処理される． 
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="element">収縮に用いる構造要素．nullの場合は, 3×3 の矩形形状の構造要素を用いる．</param>
        /// <param name="iterations">収縮の回数</param>
#else
        /// <summary>
        /// Erodes image by using arbitrary structuring element.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="element">Structuring element used for erosion. If it is null, a 3x3 rectangular structuring element is used. </param>
        /// <param name="iterations">Number of times erosion is applied. </param>
#endif
        public static void Erode(CvArr src, CvArr dst, IplConvKernel element, int iterations)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            IntPtr elem_ptr = (element == null) ? IntPtr.Zero : element.CvPtr;
            CvInvoke.cvErode(src.CvPtr, dst.CvPtr, elem_ptr, iterations);
        }
        #endregion
        #region Error
#if LANG_JP
        /// <summary>
        /// エラーを発生させる
        /// </summary>
        /// <param name="status">エラーステータス</param>
        /// <param name="func_name">エラーが発生した関数名</param>
        /// <param name="err_msg">エラーについての追加情報/診断結果</param>
        /// <param name="file_name">エラーが発生したファイル名</param>
        /// <param name="line">エラーが発生した行番号</param>
#else
        /// <summary>
        /// Raises an error
        /// </summary>
        /// <param name="status">The error status.</param>
        /// <param name="func_name">Name of the function where the error occurred. </param>
        /// <param name="err_msg">Additional information/diagnostics about the error. </param>
        /// <param name="file_name">Name of the file where the error occurred. </param>
        /// <param name="line">Line number, where the error occurred. </param>
#endif
        public static void Error(CvStatus status, string func_name, string err_msg, string file_name, int line)
        {
            if (string.IsNullOrEmpty(func_name))
                throw new ArgumentNullException("func_name");
            if (string.IsNullOrEmpty(err_msg))
                throw new ArgumentNullException("err_msg");
            if (string.IsNullOrEmpty(file_name))
                throw new ArgumentNullException("file_name");
            CvInvoke.cvError(status, func_name, err_msg, file_name, line);
        }
        #endregion
        #region ErrorStr
#if LANG_JP
        /// <summary>
        /// エラーステータスのコードのテキスト情報を返す
        /// </summary>
        /// <param name="status">エラーステータス</param>
        /// <returns>指定したエラーステータスコードのテキスト記述</returns>
#else
        /// <summary>
        /// Returns textual description of error status code
        /// </summary>
        /// <param name="status">The error status. </param>
        /// <returns>The textual description for the specified error status code.</returns>
#endif
        public static string ErrorStr(CvStatus status)
        {
            return CvInvoke.cvErrorStr(status);
        }
        #endregion
        #region EstimateRigidTransform
#if LANG_JP
        /// <summary>
        /// Estimate rigid transformation between 2 images or 2 point sets
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="M"></param>
        /// <param name="full_affine"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Estimate rigid transformation between 2 images or 2 point sets
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="M"></param>
        /// <param name="full_affine"></param>
        /// <returns></returns>
#endif
        public static int EstimateRigidTransform(CvArr A, CvArr B, CvMat M, bool full_affine)
        {
            if (A == null)
                throw new ArgumentNullException("A");
            if (B == null)
                throw new ArgumentNullException("B");
            if (M == null)
                throw new ArgumentNullException("M");

            return CvInvoke.cvEstimateRigidTransform(A.CvPtr, B.CvPtr, M.CvPtr, full_affine);
        }
        #endregion
        #region Exp
#if LANG_JP
        /// <summary>
        /// すべての配列要素について自然対数の底（ネイピア数）eのべき乗を求める
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列．倍精度の浮動小数点型（double），または入力配列と同じタイプでなければならない．</param>
#else
        /// <summary>
        /// Calculates exponent of every array element
        /// </summary>
        /// <param name="src">The source array. </param>
        /// <param name="dst">The destination array, it should have double type or the same type as the source. </param>
#endif
        public static void Exp(CvArr src, CvArr dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvExp(src.CvPtr, dst.CvPtr);
        }
        #endregion
        #region ExtractMSER
#if LANG_JP
        /// <summary>
        /// MSERのすべての輪郭情報を抽出する
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        /// <param name="contours"></param>
        /// <param name="storage"></param>
        /// <param name="params"></param>
#else
        /// <summary>
        /// Extracts the contours of Maximally Stable Extremal Regions
        /// </summary>
        /// <param name="img"></param>
        /// <param name="mask"></param>
        /// <param name="contours"></param>
        /// <param name="storage"></param>
        /// <param name="params"></param>
#endif
        public static void ExtractMSER(CvArr img, CvArr mask, out CvContour[] contours, CvMemStorage storage, CvMSERParams @params)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (storage == null)
                throw new ArgumentNullException("storage");

            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            IntPtr contoursPtr = IntPtr.Zero;

            CvInvoke.cvExtractMSER(img.CvPtr, maskPtr, ref contoursPtr, storage.CvPtr, @params.Struct);

            CvSeq<IntPtr> seq = new CvSeq<IntPtr>(contoursPtr);
            contours = Array.ConvertAll<IntPtr, CvContour>(seq.ToArray(), delegate(IntPtr p) { return new CvContour(p); });
        }
        #endregion
        #region ExtractSURF
#if LANG_JP
        /// <summary>
        /// 画像中からSURF（Speeded Up Robust Features）を検出する
        /// </summary>
        /// <param name="image">8ビット，グレースケールの入力画像． </param>
        /// <param name="mask">オプション：8ビットのマスク画像．非0 のマスクピクセルが50%以上を占める領域からのみ，特徴点検出を行う．</param>
        /// <param name="keypoints">出力パラメータ．キーポイントのシーケンスへのポインタのポインタ． これは，CvSURFPoint 構造体のシーケンスになる</param>
        /// <param name="descriptors">オプション：出力パラメータ．ディスクリプタのシーケンスへのポインタのポインタ． シーケンスの各要素は，params.extended の値に依存して， 64-要素，あるいは 128-要素の浮動小数点数（CV_32F）ベクトルとなる． パラメータが NULL の場合，ディスクリプタは計算されない．</param>
        /// <param name="storage">キーポイントとディスクリプタが格納されるメモリストレージ</param>
        /// <param name="param">CvSURFParams 構造体に入れられた，様々なアルゴリズムパラメータ</param>
#else
        /// <summary>
        /// Extracts Speeded Up Robust Features from image
        /// </summary>
        /// <param name="image">The input 8-bit grayscale image. </param>
        /// <param name="mask">The optional input 8-bit mask. The features are only found in the areas that contain more than 50% of non-zero mask pixels. </param>
        /// <param name="keypoints">The output parameter; double pointer to the sequence of keypoints. This will be the sequence of CvSURFPoint structures.</param>
        /// <param name="descriptors">The optional output parameter; double pointer to the sequence of descriptors; Depending on the params.extended value, each element of the sequence will be either 64-element or 128-element floating-point (CV_32F) vector. If the parameter is null, the descriptors are not computed. </param>
        /// <param name="storage">Memory storage where keypoints and descriptors will be stored. </param>
        /// <param name="param">Various algorithm parameters put to the structure CvSURFParams</param>
#endif
        public static void ExtractSURF(CvArr image, CvArr mask, out CvSeq<CvSURFPoint> keypoints, out CvSeq<float> descriptors, CvMemStorage storage, CvSURFParams param)
        {
            keypoints = null;
            ExtractSURF(image, mask, ref keypoints, out descriptors, storage, param, false);
        }
#if LANG_JP
        /// <summary>
        /// 画像中からSURF（Speeded Up Robust Features）を検出する
        /// </summary>
        /// <param name="image">8ビット，グレースケールの入力画像． </param>
        /// <param name="mask">オプション：8ビットのマスク画像．非0 のマスクピクセルが50%以上を占める領域からのみ，特徴点検出を行う．</param>
        /// <param name="keypoints">出力パラメータ．キーポイントのシーケンスへのポインタのポインタ． これは，CvSURFPoint 構造体のシーケンスになる</param>
        /// <param name="descriptors">オプション：出力パラメータ．ディスクリプタのシーケンスへのポインタのポインタ． シーケンスの各要素は，params.extended の値に依存して， 64-要素，あるいは 128-要素の浮動小数点数（CV_32F）ベクトルとなる． パラメータが NULL の場合，ディスクリプタは計算されない．</param>
        /// <param name="storage">キーポイントとディスクリプタが格納されるメモリストレージ</param>
        /// <param name="param">CvSURFParams 構造体に入れられた，様々なアルゴリズムパラメータ</param>
        /// <param name="useProvidedKeyPts">If useProvidedKeyPts!=0, keypoints are not detected, but descriptors are computed at the locations provided in keypoints (a CvSeq of CvSURFPoint).</param>
#else
        /// <summary>
        /// Extracts Speeded Up Robust Features from image
        /// </summary>
        /// <param name="image">The input 8-bit grayscale image. </param>
        /// <param name="mask">The optional input 8-bit mask. The features are only found in the areas that contain more than 50% of non-zero mask pixels. </param>
        /// <param name="keypoints">The output parameter; double pointer to the sequence of keypoints. This will be the sequence of CvSURFPoint structures.</param>
        /// <param name="descriptors">The optional output parameter; double pointer to the sequence of descriptors; Depending on the params.extended value, each element of the sequence will be either 64-element or 128-element floating-point (CV_32F) vector. If the parameter is null, the descriptors are not computed. </param>
        /// <param name="storage">Memory storage where keypoints and descriptors will be stored. </param>
        /// <param name="param">Various algorithm parameters put to the structure CvSURFParams</param>
        /// <param name="useProvidedKeyPts">If useProvidedKeyPts!=0, keypoints are not detected, but descriptors are computed at the locations provided in keypoints (a CvSeq of CvSURFPoint).</param>
#endif
        public static void ExtractSURF(CvArr image, CvArr mask, ref CvSeq<CvSURFPoint> keypoints, out CvSeq<float> descriptors, CvMemStorage storage, CvSURFParams param, bool useProvidedKeyPts)
        {
            if (image == null)
                throw new ArgumentNullException("img");
            if (storage == null)
                throw new ArgumentNullException("img");

            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            IntPtr descriptorsPtr = IntPtr.Zero;
            IntPtr keypointsPtr = IntPtr.Zero;
            if (useProvidedKeyPts)
            {
                keypoints = new CvSeq<CvSURFPoint>(SeqType.Zero, storage);
                keypointsPtr = keypoints.CvPtr;
                CvInvoke.cvExtractSURF(image.CvPtr, maskPtr, ref keypointsPtr, ref descriptorsPtr, storage.CvPtr, param.Struct, useProvidedKeyPts);
                descriptors = new CvSeq<float>(descriptorsPtr);
            }
            else
            {
                CvInvoke.cvExtractSURF(image.CvPtr, maskPtr, ref keypointsPtr, ref descriptorsPtr, storage.CvPtr, param.Struct, useProvidedKeyPts);
                keypoints = new CvSeq<CvSURFPoint>(keypointsPtr);
                descriptors = new CvSeq<float>(descriptorsPtr);
            }
        }
        #endregion
    }
}