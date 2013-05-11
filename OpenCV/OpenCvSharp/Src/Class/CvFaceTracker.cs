﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public class CvFaceTracker : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool _disposed = false;
        /// <summary>
        /// CV_NUM_FACE_ELEMENTS
        /// </summary>
        public const int NumFaceElements = 3;

        #region Init and Disposal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imgGray"></param>
        /// <param name="pRects"></param>
        /// <returns></returns>
        public CvFaceTracker(IplImage imgGray, CvRect[] pRects)
        {
            if (imgGray == null)
                throw new ArgumentNullException("imgGray");
            if (pRects == null)
                throw new ArgumentNullException("pRects");
            if (pRects.Length != 3)
                throw new ArgumentException("pRects.Length must be 3");

            _ptr = CvInvoke.cvInitFaceTracker(IntPtr.Zero, imgGray.CvPtr, pRects, 3);
            if (_ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create CvFaceTracker");
        }

#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvBGCodeBookModel*</param>
#else
        /// <summary>
        /// Initialize from pointer
        /// </summary>
        /// <param name="ptr">struct CvFaceTracker*</param>
#endif
        public CvFaceTracker(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                throw new ArgumentNullException("ptr");
            }
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
                    if (IsEnabledDispose)
                    {
                        CvInvoke.cvReleaseFaceTracker(ref _ptr);
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

        #region Methods
        #region TrackFace
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imgGray"></param>
        /// <param name="pRects"></param>
        /// <param name="ptRotate"></param>
        /// <param name="dbAngleRotate"></param>
        /// <returns></returns>
        public bool TrackFace(IplImage imgGray, CvRect[] pRects, out CvPoint ptRotate, out double dbAngleRotate)
        {
            return Cv.TrackFace(this, imgGray, pRects, out ptRotate, out dbAngleRotate);
        }
        #endregion
        #endregion
    }
}
