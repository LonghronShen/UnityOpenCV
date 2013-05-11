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
	/// CvFileStorageのモード
	/// </summary>
#else
    /// <summary>
    /// File storage mode
    /// </summary>
#endif
    public enum FileStorageMode : int
    {
#if LANG_JP
		/// <summary>
		/// データ読み込みのためのファイルオープン 
        /// [CV_STORAGE_READ]
		/// </summary>
#else
        /// <summary>
        /// The storage is open for reading
        /// [CV_STORAGE_READ]
        /// </summary>
#endif
        Read = CvConst.CV_STORAGE_READ,


#if LANG_JP
		/// <summary>
		/// データ書き込みのためのファイルオープン 
        /// [CV_STORAGE_WRITE]
		/// </summary>
#else
        /// <summary>
        /// The storage is open for writing
        /// [CV_STORAGE_WRITE]
        /// </summary>
#endif
        Write = CvConst.CV_STORAGE_WRITE,


#if LANG_JP
		/// <summary>
		/// テキストデータ書き込みのためのファイルオープン 
        /// [CV_STORAGE_WRITE_TEXT]
		/// </summary>
#else
        /// <summary>
        /// The storage is open for writing text data
        /// [CV_STORAGE_WRITE_TEXT]
        /// </summary>
#endif
        WriteText = CvConst.CV_STORAGE_WRITE_TEXT,


#if LANG_JP
		/// <summary>
		/// バイナリデータ書き込みのためのファイルオープン 
        /// [CV_STORAGE_WRITE_BINARY]
		/// </summary>
#else
        /// <summary>
        /// The storage is open for writing binary data
        /// [CV_STORAGE_WRITE_BINARY]
        /// </summary>
#endif
        WriteBinary = CvConst.CV_STORAGE_WRITE_BINARY,


#if LANG_JP
		/// <summary>
		/// データ追加書き込みのためのファイルオープン 
        /// [CV_STORAGE_APPEND]
		/// </summary>
#else
        /// <summary>
        /// The storage is open for appending
        /// [CV_STORAGE_APPEND]
        /// </summary>
#endif
        Append = CvConst.CV_STORAGE_APPEND,
    }
}
