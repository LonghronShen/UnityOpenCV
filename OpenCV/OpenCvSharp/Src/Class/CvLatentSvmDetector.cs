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
    /// structure contains the bounding box and confidence level for detected object 
    /// </summary>
#else
    /// <summary>
    /// structure contains the bounding box and confidence level for detected object 
    /// </summary>
#endif
    public class CvLatentSvmDetector : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool _disposed = false;

        #region Init and disposal
#if LANG_JP
        /// <summary>
        /// load trained detector from a file
        /// </summary>
        /// <param name="filename"></param>
#else
        /// <summary>
        /// load trained detector from a file
        /// </summary>
        /// <param name="filename"></param>
#endif
        public CvLatentSvmDetector(string filename)
        {
            _ptr = CvInvoke.cvLoadLatentSvmDetector(filename);
            if (_ptr == IntPtr.Zero)
            {
                throw new OpenCvSharpException("Failed to create CvLatentSvmDetector");
            }
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvLSH*</param>
#else
        /// <summary>
        /// Initializes from pointer
        /// </summary>
        /// <param name="ptr">struct CvLatentSvmDetector*</param>
#endif
        public CvLatentSvmDetector(IntPtr ptr)
        {
            this._ptr = ptr;
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvLSH*</param>
#else
        /// <summary>
        /// Initializes from pointer
        /// </summary>
        /// <param name="ptr">struct CvLSH*</param>
#endif
        public static CvLatentSvmDetector FromPtr(IntPtr ptr)
        {
            return new CvLatentSvmDetector(ptr);
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
                        CvInvoke.cvReleaseLatentSvmDetector(ref _ptr);
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
        #region DetectObjects
#if LANG_JP
        /// <summary>
        /// find rectangular regions in the given image that are likely 
        /// to contain objects and corresponding confidence levels
        /// </summary>
        /// <param name="image"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// find rectangular regions in the given image that are likely 
        /// to contain objects and corresponding confidence levels
        /// </summary>
        /// <param name="image">image to detect objects in</param>
        /// <param name="storage">memory storage to store the resultant sequence of the object candidate rectangles</param>
        /// <returns></returns>      
#endif
        public CvSeq<CvObjectDetection> DetectObjects(IplImage image, CvMemStorage storage)
        {
            return Cv.LatentSvmDetectObjects(image, this, storage);
        }
#if LANG_JP
        /// <summary>
        /// find rectangular regions in the given image that are likely 
        /// to contain objects and corresponding confidence levels
        /// </summary>
        /// <param name="image"></param>
        /// <param name="storage"></param>
        /// <param name="overlap_threshold"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// find rectangular regions in the given image that are likely 
        /// to contain objects and corresponding confidence levels
        /// </summary>
        /// <param name="image">image to detect objects in</param>
        /// <param name="storage">memory storage to store the resultant sequence of the object candidate rectangles</param>
        /// <param name="overlap_threshold">threshold for the non-maximum suppression algorithm 
        ///  = 0.5f [here will be the reference to original paper]</param>
        /// <returns></returns>   
#endif
        public CvSeq<CvObjectDetection> DetectObjects(IplImage image, CvMemStorage storage, float overlap_threshold)
        {
            return Cv.LatentSvmDetectObjects(image, this, storage, overlap_threshold);
        }
#if LANG_JP
        /// <summary>
        /// find rectangular regions in the given image that are likely 
        /// to contain objects and corresponding confidence levels
        /// </summary>
        /// <param name="image"></param>
        /// <param name="storage"></param>
        /// <param name="overlap_threshold"></param>
        /// <param name="numThreads"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// find rectangular regions in the given image that are likely 
        /// to contain objects and corresponding confidence levels
        /// </summary>
        /// <param name="image">image to detect objects in</param>
        /// <param name="storage">memory storage to store the resultant sequence of the object candidate rectangles</param>
        /// <param name="overlap_threshold">threshold for the non-maximum suppression algorithm 
        ///  = 0.5f [here will be the reference to original paper]</param>
        /// <param name="numThreads"></param>
        /// <returns></returns>   
#endif
        public CvSeq<CvObjectDetection> DetectObjects(IplImage image, CvMemStorage storage, float overlap_threshold, int numThreads)
        {
            return Cv.LatentSvmDetectObjects(image, this, storage, overlap_threshold, numThreads);
        }
        #endregion
        #endregion

        #region Properties
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int NumFilters
        {
            get
            {
                unsafe
                {
                    return ((WCvLatentSvmDetector*)_ptr)->num_filters;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvLatentSvmDetector*)_ptr)->num_filters = value;
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int NumComponents
        {
            get
            {
                unsafe
                {
                    return ((WCvLatentSvmDetector*)_ptr)->num_components;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvLatentSvmDetector*)_ptr)->num_components = value;
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public unsafe int* NumPartFilters
        {
            get
            {
                unsafe
                {
                    return ((WCvLatentSvmDetector*)_ptr)->num_part_filters;
                }
            }
            internal set
            {
                unsafe
                {
                    ((WCvLatentSvmDetector*)_ptr)->num_part_filters = value;
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public IntPtr Filters
        {
            get
            {
                unsafe
                {
                    return (IntPtr)((WCvLatentSvmDetector*)_ptr)->filters;
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public unsafe float* B
        {
            get
            {
                unsafe
                {
                    return ((WCvLatentSvmDetector*)_ptr)->b;
                }
            }
            internal set
            {
                unsafe
                {
                    ((WCvLatentSvmDetector*)_ptr)->b = value;
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public float ScoreThreshold
        {
            get
            {
                unsafe
                {
                    return ((WCvLatentSvmDetector*)_ptr)->score_threshold;
                }
            }
            internal set
            {
                unsafe
                {
                    ((WCvLatentSvmDetector*)_ptr)->score_threshold = value;
                }
            }
        }
        #endregion
    }
}
