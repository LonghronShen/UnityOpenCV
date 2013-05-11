﻿/*
 * (C) 2008-2012 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
#if LANG_JP
	/// <summary>
	/// ビデオファイル内の相対的な位置
	/// </summary>
#else
    /// <summary>
    /// Position in relative units
    /// </summary>
#endif
    public enum CapturePosAviRatio : int
    {
#if LANG_JP
        /// <summary>
        /// ファイルの最初
        /// </summary>
#else
        /// <summary>
        /// Start of the file
        /// </summary>
#endif
        Start = 0,

#if LANG_JP
        /// <summary>
        /// ファイルの最後
        /// </summary>
#else
        /// <summary>
        /// End of the file
        /// </summary>
#endif
        End = 1,
    }
}
