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
    /// リソースを解放すべきOpenCVのクラスに継承させる基本クラス
    /// </summary>
#else
    /// <summary>
    /// DisposableObject + ICvPtrHolder
    /// </summary>
#endif
    abstract public class DisposableCvObject : DisposableObject, ICvPtrHolder
    {
        /// <summary>
        /// Data pointer
        /// </summary>
        protected IntPtr _ptr;
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool _disposed = false;

        #region Init and Dispose
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public DisposableCvObject()
            : this(true)
        {
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public DisposableCvObject(IntPtr ptr)
            : this(ptr, true)
        {
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isEnabledDispose"></param>
#else
        /// <summary>
        ///  
        /// </summary>
        /// <param name="isEnabledDispose"></param>
#endif
        public DisposableCvObject(bool isEnabledDispose)
            : this(IntPtr.Zero, isEnabledDispose)
        {
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="isEnabledDispose"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="isEnabledDispose"></param>
#endif
        public DisposableCvObject(IntPtr ptr, bool isEnabledDispose)
            : base(isEnabledDispose)
        {
            this._ptr = ptr;
        }

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
        /// <param name="disposing">
        /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
        /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
        ///</param>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {
                    }
                    this._disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

#if LANG_JP
        /// <summary>
        /// OpenCVの構造体へのネイティブポインタ
        /// </summary>
#else
        /// <summary>
        /// Native pointer of OpenCV structure
        /// </summary>
#endif
        public IntPtr CvPtr
        {
            get { return _ptr; }
        }
    }
}
