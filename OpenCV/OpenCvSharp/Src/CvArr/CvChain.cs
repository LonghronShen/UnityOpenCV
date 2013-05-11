﻿/*
 * (C) 2008-2012 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 輪郭データ
    /// </summary>
#else
    /// <summary>
    /// 
    /// </summary>
#endif
    public class CvChain : CvSeq<CvPoint> 
    {
        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// ネイティブのデータポインタから初期化
        /// </summary>
        /// <param name="ptr"></param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public CvChain(IntPtr ptr)
            : base(ptr)
        {
            this._ptr = ptr;
        }

        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvChain) 
        /// </summary>
        new public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvChain));

        /// <summary>
        /// 
        /// </summary>
        public CvPoint Origin
        {
            get
            {
                unsafe
                {
                    return ((WCvChain*)_ptr)->origin;
                }
            }
        }
        #endregion

        #region Methods
        #region ApproxChains
#if LANG_JP
        /// <summary>
        /// フリーマンチェーン（Freeman chain）をポリラインで近似する
        /// </summary>
        /// <param name="storage">計算結果保存用のストレージ．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Approximates Freeman chain(s) with polygonal curve
        /// </summary>
        /// <param name="storage">Storage location for the resulting polylines. </param>
        /// <returns></returns>
#endif
        public CvSeq<CvPoint> ApproxChains(CvMemStorage storage)
        {
            return Cv.ApproxChains(this, storage);
        }
#if LANG_JP
        /// <summary>
        /// フリーマンチェーン（Freeman chain）をポリラインで近似する
        /// </summary>
        /// <param name="storage">計算結果保存用のストレージ．</param>
        /// <param name="method">推定手法.</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Approximates Freeman chain(s) with polygonal curve
        /// </summary>
        /// <param name="storage">Storage location for the resulting polylines. </param>
        /// <param name="method">Approximation method.</param>
        /// /// <returns></returns>
#endif
        public CvSeq<CvPoint> ApproxChains(CvMemStorage storage, ContourChain method)
        {
            return Cv.ApproxChains(this, storage, method);
        }
#if LANG_JP
        /// <summary>
        /// フリーマンチェーン（Freeman chain）をポリラインで近似する
        /// </summary>
        /// <param name="storage">計算結果保存用のストレージ．</param>
        /// <param name="method">推定手法.</param>
        /// <param name="parameter">メソッドパラメータ（現在は使われていない）．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Approximates Freeman chain(s) with polygonal curve
        /// </summary>
        /// <param name="storage">Storage location for the resulting polylines. </param>
        /// <param name="method">Approximation method.</param>
        /// <param name="parameter">Method parameter (not used now). </param>
        /// <returns></returns>
#endif
        public CvSeq<CvPoint> ApproxChains(CvMemStorage storage, ContourChain method, double parameter)
        {
            return Cv.ApproxChains(this, storage, method, parameter);
        }
#if LANG_JP
        /// <summary>
        /// フリーマンチェーン（Freeman chain）をポリラインで近似する
        /// </summary>
        /// <param name="storage">計算結果保存用のストレージ．</param>
        /// <param name="method">推定手法.</param>
        /// <param name="parameter">メソッドパラメータ（現在は使われていない）．</param>
        /// <param name="minimal_perimeter">minimal_perimeter以上の周囲長をもつ輪郭のみを計算する．その他のチェーンは結果の構造体から削除される．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Approximates Freeman chain(s) with polygonal curve
        /// </summary>
        /// <param name="storage">Storage location for the resulting polylines. </param>
        /// <param name="method">Approximation method.</param>
        /// <param name="parameter">Method parameter (not used now). </param>
        /// <param name="minimal_perimeter">Approximates only those contours whose perimeters are not less than minimal_perimeter. Other chains are removed from the resulting structure. </param>
        /// <returns></returns>
#endif
        public CvSeq<CvPoint> ApproxChains(CvMemStorage storage, ContourChain method, double parameter, int minimal_perimeter)
        {
            return Cv.ApproxChains(this, storage, method, parameter, minimal_perimeter);
        }
#if LANG_JP
        /// <summary>
        /// フリーマンチェーン（Freeman chain）をポリラインで近似する
        /// </summary>
        /// <param name="storage">計算結果保存用のストレージ．</param>
        /// <param name="method">推定手法.</param>
        /// <param name="parameter">メソッドパラメータ（現在は使われていない）．</param>
        /// <param name="minimal_perimeter">minimal_perimeter以上の周囲長をもつ輪郭のみを計算する．その他のチェーンは結果の構造体から削除される．</param>
        /// <param name="recursive">trueの場合，src_seqからh_nextあるいはv_nextによって辿ることができる全てのチェーンを近似する．falseの場合，単一のチェーンを近似する． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Approximates Freeman chain(s) with polygonal curve
        /// </summary>
        /// <param name="storage">Storage location for the resulting polylines. </param>
        /// <param name="method">Approximation method.</param>
        /// <param name="parameter">Method parameter (not used now). </param>
        /// <param name="minimal_perimeter">Approximates only those contours whose perimeters are not less than minimal_perimeter. Other chains are removed from the resulting structure. </param>
        /// <param name="recursive">If true, the function approximates all chains that access can be obtained to from src_seq by h_next or v_next links. If false, the single chain is approximated. </param>
        /// <returns></returns>
#endif
        public CvSeq<CvPoint> ApproxChains(CvMemStorage storage, ContourChain method, double parameter, int minimal_perimeter, bool recursive)
        {
            return Cv.ApproxChains(this, storage, method, parameter, minimal_perimeter, recursive);
        }
        #endregion
        #endregion
    }
}
