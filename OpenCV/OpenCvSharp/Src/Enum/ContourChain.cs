/*
 * (C) 2008-2012 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// 輪郭の近似手法
	/// </summary>
#else
    /// <summary>
    /// Approximation method (for all the modes, except CV_RETR_RUNS, which uses built-in approximation). 
    /// </summary>
#endif
    public enum ContourChain : int
    {
#if LANG_JP
		/// <summary>
        /// 最も外側の輪郭のみ抽出 [CV_CHAIN_CODE]
		/// </summary>
#else
        /// <summary>
        /// CV_CHAIN_CODE - output contours in the Freeman chain code. All other methods output polygons (sequences of vertices). 
        /// </summary>
#endif
        Code = CvConst.CV_CHAIN_CODE,


#if LANG_JP
		/// <summary>
        /// 最も外側の輪郭のみ抽出 [CV_CHAIN_APPROX_NONE]
		/// </summary>
#else
        /// <summary>
        /// CV_CHAIN_APPROX_NONE - translate all the points from the chain code into points; 
        /// </summary>
#endif
        ApproxNone = CvConst.CV_CHAIN_APPROX_NONE,


#if LANG_JP
		/// <summary>
        /// 最も外側の輪郭のみ抽出 [CV_CHAIN_APPROX_SIMPLE]
		/// </summary>
#else
        /// <summary>
        /// CV_CHAIN_APPROX_SIMPLE - compress horizontal, vertical, and diagonal segments, that is, the function leaves only their ending points; 
        /// </summary>
#endif
        ApproxSimple = CvConst.CV_CHAIN_APPROX_SIMPLE,


#if LANG_JP
		/// <summary>
        /// 最も外側の輪郭のみ抽出 [CV_CHAIN_APPROX_TC89_L1]
		/// </summary>
#else
        /// <summary>
        /// CV_CHAIN_APPROX_TC89_L1 - apply one of the flavors of Teh-Chin chain approximation algorithm. 
        /// </summary>
#endif
        ApproxTC89L1 = CvConst.CV_CHAIN_APPROX_TC89_L1,


#if LANG_JP
		/// <summary>
        /// 最も外側の輪郭のみ抽出 [CV_CHAIN_APPROX_TC89_KCOS]
		/// </summary>
#else
        /// <summary>
        /// V_CHAIN_APPROX_TC89_KCOS - apply one of the flavors of Teh-Chin chain approximation algorithm. 
        /// </summary>
#endif
        ApproxTC89KCOS = CvConst.CV_CHAIN_APPROX_TC89_KCOS,


#if LANG_JP
		/// <summary>
        /// 最も外側の輪郭のみ抽出 [CV_LINK_RUN_]
		/// </summary>
#else
        /// <summary>
        /// CV_LINK_RUNS - use completely different contour retrieval algorithm via linking of horizontal segments of 1’s. Only CV_RETR_LIST retrieval mode can be used with this method. 
        /// </summary>
#endif
        LinkRuns = CvConst.CV_LINK_RUNS,
    }
}
