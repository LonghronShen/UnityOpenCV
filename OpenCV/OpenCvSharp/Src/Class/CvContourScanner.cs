/*
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
    /// 輪郭スキャナ
    /// </summary>
#else
    /// <summary>
    /// CvcontourScanner
    /// </summary>
#endif
    public class CvContourScanner : DisposableCvObject, IEnumerable<CvSeq<CvPoint>>
    {
        #region Fields
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool _disposed = false;
        private CvArr _image;
        private CvMemStorage _storage;
        private int _header_size;
        private ContourRetrieval _mode;
        private ContourChain _method;
        private CvPoint _offset;
        #endregion

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理の初期化を行う
        /// </summary>
        /// <param name="image">入力画像．8ビットシングルチャンネルの2値化画像． </param>
        /// <param name="storage">抽出された輪郭データの保存領域． </param>
#else
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="image">The source 8-bit single channel binary image. </param>
        /// <param name="storage">Container of the retrieved contours.</param>
#endif
        public CvContourScanner(CvArr image, CvMemStorage storage)
            : this(image, storage, CvContour.SizeOf, ContourRetrieval.List, ContourChain.ApproxSimple, new CvPoint(0, 0))
        {
        }
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理の初期化を行う
        /// </summary>
        /// <param name="image">入力画像．8ビットシングルチャンネルの2値化画像． </param>
        /// <param name="storage">抽出された輪郭データの保存領域． </param>
        /// <param name="header_size"></param>
#else
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="image">The source 8-bit single channel binary image. </param>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="header_size">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
#endif
        public CvContourScanner(CvArr image, CvMemStorage storage, int header_size)
            : this(image, storage, header_size, ContourRetrieval.List, ContourChain.ApproxSimple, new CvPoint(0, 0))
        {
        }
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理の初期化を行う
        /// </summary>
        /// <param name="image">入力画像．8ビットシングルチャンネルの2値化画像． </param>
        /// <param name="storage">抽出された輪郭データの保存領域． </param>
        /// <param name="header_size">シーケンスヘッダのサイズ． method=CV_CHAIN_CODEの時， >=sizeof(CvChain) ，それ以外の場合 >=sizeof(CvContour)． </param>
        /// <param name="mode">抽出モード．</param>
#else
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="image">The source 8-bit single channel binary image. </param>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="header_size">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <param name="mode">Retrieval mode; see cvFindContours. </param>
#endif
        public CvContourScanner(CvArr image, CvMemStorage storage, int header_size, ContourRetrieval mode)
            : this(image, storage, header_size, mode, ContourChain.ApproxSimple, new CvPoint(0, 0))
        {
        }
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理の初期化を行う
        /// </summary>
        /// <param name="image">入力画像．8ビットシングルチャンネルの2値化画像． </param>
        /// <param name="storage">抽出された輪郭データの保存領域． </param>
        /// <param name="header_size">シーケンスヘッダのサイズ． method=CV_CHAIN_CODEの時， >=sizeof(CvChain) ，それ以外の場合 >=sizeof(CvContour)． </param>
        /// <param name="mode">抽出モード．</param>
        /// <param name="method">近似手法．cvFindContoursと同様，但し CV_LINK_RUNS は使用不可． </param>
#else
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="image">The source 8-bit single channel binary image. </param>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="header_size">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <param name="mode">Retrieval mode; see cvFindContours. </param>
        /// <param name="method">Approximation method. It has the same meaning as in cvFindContours, but CV_LINK_RUNS can not be used here. </param>
#endif
        public CvContourScanner(CvArr image, CvMemStorage storage, int header_size, ContourRetrieval mode, ContourChain method)
            : this(image, storage, header_size, mode, method, new CvPoint(0, 0))
        {
        }
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理の初期化を行う
        /// </summary>
        /// <param name="image">入力画像．8ビットシングルチャンネルの2値化画像． </param>
        /// <param name="storage">抽出された輪郭データの保存領域． </param>
        /// <param name="header_size">シーケンスヘッダのサイズ． method=CV_CHAIN_CODEの時， >=sizeof(CvChain) ，それ以外の場合 >=sizeof(CvContour)． </param>
        /// <param name="mode">抽出モード．</param>
        /// <param name="method">近似手法．cvFindContoursと同様，但し CV_LINK_RUNS は使用不可． </param>
        /// <param name="offset">ROIのオフセット．cvFindContoursを参照． </param>
        /// <returns>輪郭スキャナのポインタ</returns>
#else
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="image">The source 8-bit single channel binary image. </param>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="header_size">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <param name="mode">Retrieval mode; see cvFindContours. </param>
        /// <param name="method">Approximation method. It has the same meaning as in cvFindContours, but CV_LINK_RUNS can not be used here. </param>
        /// <param name="offset">ROI offset; see cvFindContours. </param>
        /// <returns>CvContourScanner</returns>
#endif
        public CvContourScanner(CvArr image, CvMemStorage storage, int header_size, ContourRetrieval mode, ContourChain method, CvPoint offset)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (storage == null)
                throw new ArgumentNullException("storage");
            Initialize(image, storage, header_size, mode, method, offset);
        }

        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="image">The source 8-bit single channel binary image. </param>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="header_size">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <param name="mode">Retrieval mode; see cvFindContours. </param>
        /// <param name="method">Approximation method. It has the same meaning as in cvFindContours, but CV_LINK_RUNS can not be used here. </param>
        /// <param name="offset">ROI offset; see cvFindContours. </param>
        /// <returns>CvContourScanner</returns>
        private void Initialize(CvArr image, CvMemStorage storage, int header_size, ContourRetrieval mode, ContourChain method, CvPoint offset)
        {
            this._image = image;
            this._storage = storage;
            this._header_size = header_size;
            this._mode = mode;
            this._method = method;
            this._offset = offset;
            if (this._ptr != IntPtr.Zero)
            {
                CvInvoke.cvEndFindContours(ref this._ptr);
            }
            this._ptr = CvInvoke.cvStartFindContours(image.CvPtr, storage.CvPtr, header_size, mode, method, offset);
        }
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        private void Initialize()
        {
            Initialize(_image, _storage, _header_size, _mode, _method, _offset);
        }

        #region StartFindContours
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理の初期化を行う
        /// </summary>
        /// <param name="image">入力画像．8ビットシングルチャンネルの2値化画像． </param>
        /// <param name="storage">抽出された輪郭データの保存領域． </param>
        /// <returns>輪郭スキャナのポインタ</returns>
#else
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="image">The source 8-bit single channel binary image. </param>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <returns>CvContourScanner</returns>
#endif
        public static CvContourScanner StartFindContours(CvArr image, CvMemStorage storage)
        {
            return new CvContourScanner(image, storage, CvContour.SizeOf, ContourRetrieval.List, ContourChain.ApproxSimple, new CvPoint(0, 0));
        }
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理の初期化を行う
        /// </summary>
        /// <param name="image">入力画像．8ビットシングルチャンネルの2値化画像． </param>
        /// <param name="storage">抽出された輪郭データの保存領域． </param>
        /// <param name="header_size"></param>
        /// <returns>輪郭スキャナのポインタ</returns>
#else
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="image">The source 8-bit single channel binary image. </param>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="header_size">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <returns>CvContourScanner</returns>
#endif
        public static CvContourScanner StartFindContours(CvArr image, CvMemStorage storage, int header_size)
        {
            return new CvContourScanner(image, storage, header_size, ContourRetrieval.List, ContourChain.ApproxSimple, new CvPoint(0, 0));
        }
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理の初期化を行う
        /// </summary>
        /// <param name="image">入力画像．8ビットシングルチャンネルの2値化画像． </param>
        /// <param name="storage">抽出された輪郭データの保存領域． </param>
        /// <param name="header_size">シーケンスヘッダのサイズ． method=CV_CHAIN_CODEの時， >=sizeof(CvChain) ，それ以外の場合 >=sizeof(CvContour)． </param>
        /// <param name="mode">抽出モード．</param>
        /// <returns>輪郭スキャナのポインタ</returns>
#else
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="image">The source 8-bit single channel binary image. </param>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="header_size">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <param name="mode">Retrieval mode; see cvFindContours. </param>
        /// <returns>CvContourScanner</returns>
#endif
        public static CvContourScanner StartFindContours(CvArr image, CvMemStorage storage, int header_size, ContourRetrieval mode)
        {
            return new CvContourScanner(image, storage, header_size, mode, ContourChain.ApproxSimple, new CvPoint(0, 0));
        }
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理の初期化を行う
        /// </summary>
        /// <param name="image">入力画像．8ビットシングルチャンネルの2値化画像． </param>
        /// <param name="storage">抽出された輪郭データの保存領域． </param>
        /// <param name="header_size">シーケンスヘッダのサイズ． method=CV_CHAIN_CODEの時， >=sizeof(CvChain) ，それ以外の場合 >=sizeof(CvContour)． </param>
        /// <param name="mode">抽出モード．</param>
        /// <param name="method">近似手法．cvFindContoursと同様，但し CV_LINK_RUNS は使用不可． </param>
        /// <returns>輪郭スキャナのポインタ</returns>
#else
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="image">The source 8-bit single channel binary image. </param>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="header_size">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <param name="mode">Retrieval mode; see cvFindContours. </param>
        /// <param name="method">Approximation method. It has the same meaning as in cvFindContours, but CV_LINK_RUNS can not be used here. </param>
        /// <returns>CvContourScanner</returns>
#endif
        public static CvContourScanner StartFindContours(CvArr image, CvMemStorage storage, int header_size, ContourRetrieval mode, ContourChain method)
        {
            return new CvContourScanner(image, storage, header_size, mode, method, new CvPoint(0, 0));
        }
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理の初期化を行う
        /// </summary>
        /// <param name="image">入力画像．8ビットシングルチャンネルの2値化画像． </param>
        /// <param name="storage">抽出された輪郭データの保存領域． </param>
        /// <param name="header_size">シーケンスヘッダのサイズ． method=CV_CHAIN_CODEの時， >=sizeof(CvChain) ，それ以外の場合 >=sizeof(CvContour)． </param>
        /// <param name="mode">抽出モード．</param>
        /// <param name="method">近似手法．cvFindContoursと同様，但し CV_LINK_RUNS は使用不可． </param>
        /// <param name="offset">ROIのオフセット．cvFindContoursを参照． </param>
        /// <returns>輪郭スキャナのポインタ</returns>
#else
        /// <summary>
        /// Initializes contour scanning process
        /// </summary>
        /// <param name="image">The source 8-bit single channel binary image. </param>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="header_size">Size of the sequence header, >=sizeof(CvChain) if method=CV_CHAIN_CODE, and >=sizeof(CvContour) otherwise. </param>
        /// <param name="mode">Retrieval mode; see cvFindContours. </param>
        /// <param name="method">Approximation method. It has the same meaning as in cvFindContours, but CV_LINK_RUNS can not be used here. </param>
        /// <param name="offset">ROI offset; see cvFindContours. </param>
        /// <returns>CvContourScanner</returns>
#endif
        public static CvContourScanner StartFindContours(CvArr image, CvMemStorage storage, int header_size, ContourRetrieval mode, ContourChain method, CvPoint offset)
        {
            return new CvContourScanner(image, storage, header_size, mode, method, offset);
        }
        #endregion

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
                    CvInvoke.cvEndFindContours(ref _ptr);
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
        #region EndFindContours
#if LANG_JP
        /// <summary>
        /// 輪郭走査処理を終了する
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Finishes scanning process
        /// </summary>
        /// <returns></returns>
#endif
        public CvSeq<CvPoint> EndFindContours()
        {
            IntPtr ptr = CvPtr;
            IntPtr result = CvInvoke.cvEndFindContours(ref ptr);
            _disposed = true;
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvSeq<CvPoint>(result);
        }
        #endregion
        #region FindNextContour
#if LANG_JP
        /// <summary>
        /// 画像中の次の輪郭を検索する
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds next contour in the image
        /// </summary>
#endif
        public CvSeq<CvPoint> FindNextContour()
        {
            return Cv.FindNextContour(this);
        }
        #endregion
        #region SubstituteContour
#if LANG_JP
        /// <summary>
        /// 抽出された輪郭を置き換える
        /// </summary>
        /// <param name="new_contour">新しく置き換える輪郭</param>
#else
        /// <summary>
        /// Replaces retrieved contour
        /// </summary>
        /// <param name="new_contour">Substituting contour. </param>
#endif
        public void SubstituteContour(CvSeq<CvPoint> new_contour)
        {
            Cv.SubstituteContour(this, new_contour);
        }
        #endregion
        #endregion

        #region IEnumerable<CvSeq<CvPoint>>
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns> A System.Collections.Generic.IEnumerator&lt;T&gt; that can be used to iterate through the collection.</returns>
        public IEnumerator<CvSeq<CvPoint>> GetEnumerator()
        {
            Initialize();
            while (true)
            {
                CvSeq<CvPoint> c = Cv.FindNextContour(this);
                if (c == null)
                    break;
                else
                    yield return c;
            }
            Cv.EndFindContours(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}