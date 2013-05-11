﻿/*
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
	/// 配列の反転方法
	/// </summary>
#else
    /// <summary>
    /// Specifies how to flip the array
    /// </summary>
#endif
    public enum FlipMode : int
    {
#if LANG_JP
		/// <summary>
		/// x軸周りでの反転
		/// </summary>
#else
        /// <summary>
        /// means flipping around x-axis
        /// </summary>
#endif
        X = 0,


#if LANG_JP
		/// <summary>
		/// y軸周りでの反転
		/// </summary>
#else
        /// <summary>
        /// means flipping around y-axis
        /// </summary>
#endif
        Y = 1,


#if LANG_JP
		/// <summary>
		/// 両軸周りでの反転
		/// </summary>
#else
        /// <summary>
        /// means flipping around both axises
        /// </summary>
#endif
        XY = -1
    }
}
