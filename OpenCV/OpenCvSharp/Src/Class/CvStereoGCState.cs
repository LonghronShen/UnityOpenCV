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
    /// グラフカットに基づくステレオマッチングのための構造体
    /// </summary>
#else
    /// <summary>
    /// The structure for graph cuts-based stereo correspondence algorithm
    /// </summary>
#endif
    public class CvStereoGCState : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool _disposed = false;

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// グラフカットステレオマッチングアルゴリズムの構造体を作成する (cvCreateStereoGCState)
        /// </summary>
        /// <param name="numberOfDisparities">視差数．視差の探索範囲は， state-&gt;minDisparity &lt;= disparity &lt; state-&gt;minDisparity + state-&gt;numberOfDisparities となる．</param>
        /// <param name="maxIters">繰り返し計算の最大数． 各繰り返しにおいて，すべての（あるいは，適度な数の）α拡張を行う． このアルゴリズムは，コスト関数全体を減少させるα拡張が見つからなかった場合は，そこで終了する．</param>
#else
        /// <summary>
        /// Creates the state of graph cut-based stereo correspondence algorithm (cvCreateStereoGCState)
        /// </summary>
        /// <param name="numberOfDisparities">The number of disparities. The disparity search range will be state-&gt;minDisparity ≤ disparity &lt; state-&gt;minDisparity + state-&gt;numberOfDisparities</param>
        /// <param name="maxIters">Maximum number of iterations. On each iteration all possible (or reasonable) alpha-expansions are tried. The algorithm may terminate earlier if it could not find an alpha-expansion that decreases the overall cost function value.</param>
#endif        
        public CvStereoGCState(int numberOfDisparities, int maxIters)
        {
            this._ptr = CvInvoke.cvCreateStereoGCState(numberOfDisparities, maxIters);
            if (this._ptr == IntPtr.Zero)
            {
                throw new OpenCvSharpException("Failed to create CvStereoBMState");
            }
            NotifyMemoryPressure(SizeOf);
        }

#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">CvStereoGCState*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public CvStereoGCState(IntPtr ptr)
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
                    if (IsEnabledDispose)
                    {
                        CvInvoke.cvReleaseStereoGCState(ref _ptr);
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

        #region Properties
        /// <summary>
        /// sizeof(CvStereoGCState) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvStereoGCState));


#if LANG_JP
		/// <summary>
		/// データ項の閾値（デフォルトでは 5）
        /// </summary>
#else
        /// <summary>
        /// threshold for piece-wise linear data cost function (5 by default)
        /// </summary>
#endif
        public int Ithreshold
        {
            get
            {
                unsafe
                {
                    return ((WCvStereoGCState*)_ptr)->Ithreshold;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvStereoGCState*)_ptr)->Ithreshold = value;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// 平滑化項の範囲（デフォルトでは 1，Pottsモデル）
        /// </summary>
#else
        /// <summary>
        /// radius for smoothness cost function (1 by default; means Potts model)
        /// </summary>
#endif
        public int InteractionRadius
        {
            get
            {
                unsafe
                {
                    return ((WCvStereoGCState*)_ptr)->interactionRadius;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvStereoGCState*)_ptr)->interactionRadius = value;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// コスト関数のパラメータ（通常は，入力データから適応的に求められる）
        /// </summary>
#else
        /// <summary>
        /// parameters for the cost function (usually computed adaptively from the input data)
        /// </summary>
#endif
        public float K
        {
            get
            {
                unsafe
                {
                    return ((WCvStereoGCState*)_ptr)->K;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvStereoGCState*)_ptr)->K = value;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// コスト関数のパラメータ（通常は，入力データから適応的に求められる）
        /// </summary>
#else
        /// <summary>
        /// parameters for the cost function (usually computed adaptively from the input data)
        /// </summary>
#endif
        public float Lambda
        {
            get
            {
                unsafe
                {
                    return ((WCvStereoGCState*)_ptr)->lambda;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvStereoGCState*)_ptr)->lambda = value;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// コスト関数のパラメータ（通常は，入力データから適応的に求められる）
        /// </summary>
#else
        /// <summary>
        /// parameters for the cost function (usually computed adaptively from the input data)
        /// </summary>
#endif
        public float Lambda1
        {
            get
            {
                unsafe
                {
                    return ((WCvStereoGCState*)_ptr)->lambda1;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvStereoGCState*)_ptr)->lambda1 = value;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// コスト関数のパラメータ（通常は，入力データから適応的に求められる）
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public float Lambda2
        {
            get
            {
                unsafe
                {
                    return ((WCvStereoGCState*)_ptr)->lambda2;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvStereoGCState*)_ptr)->lambda2 = value;
                }
            }
        }

#if LANG_JP
		/// <summary>
		/// オクルージョンのコスト? (デフォルトで1000)
        /// </summary>
#else
        /// <summary>
        /// cost of occlusion (10000 by default)
        /// </summary>
#endif
        public int OcclusionCost
        {
            get
            {
                unsafe
                {
                    return ((WCvStereoGCState*)_ptr)->occlusionCost;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvStereoGCState*)_ptr)->occlusionCost = value;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// SAD(Sum of Absolute Difference)の最小視差 (=0)
        /// </summary>
#else
        /// <summary>
        /// minimum disparity of SAD(Sum of Absolute Difference) (0 by default)
        /// </summary>
#endif
        public int MinDisparity
        {
            get
            {
                unsafe
                {
                    return ((WCvStereoGCState*)_ptr)->minDisparity;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvStereoGCState*)_ptr)->minDisparity = value;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// SAD(Sum of Absolute Difference)の 最大視差-最小視差
        /// </summary>
#else
        /// <summary>
        /// maximum disparity - minimum disparity of SAD(Sum of Absolute Difference) ; defined by user
        /// </summary>
#endif
        public int NumberOfDisparities
        {
            get
            {
                unsafe
                {
                    return ((WCvStereoGCState*)_ptr)->numberOfDisparities;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvStereoGCState*)_ptr)->numberOfDisparities = value;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// 繰り返し計算の回数
        /// </summary>
#else
        /// <summary>
        /// number of iterations; defined by user.
        /// </summary>
#endif
        public int MaxIters
        {
            get
            {
                unsafe
                {
                    return ((WCvStereoGCState*)_ptr)->maxIters;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvStereoGCState*)_ptr)->maxIters = value;
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
        public CvMat Left
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvStereoGCState*)_ptr)->left);
                    return new CvMat(p, false);
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
        public CvMat Right
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvStereoGCState*)_ptr)->right);
                    return new CvMat(p, false);
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
        public CvMat DispLeft
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvStereoGCState*)_ptr)->dispLeft);
                    return new CvMat(p, false);
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
        public CvMat DispRight
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvStereoGCState*)_ptr)->dispRight);
                    return new CvMat(p, false);
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
        public CvMat PtrLeft
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvStereoGCState*)_ptr)->ptrLeft);
                    return new CvMat(p, false);
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
        public CvMat PtrRight
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvStereoGCState*)_ptr)->ptrRight);
                    return new CvMat(p, false);
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
        public CvMat VtxBuf
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvStereoGCState*)_ptr)->vtxBuf);
                    return new CvMat(p, false);
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
        public CvMat EdgeBuf
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvStereoGCState*)_ptr)->edgeBuf);
                    return new CvMat(p, false);
                }
            }
        }
        #endregion

        #region Methods
#if LANG_JP
        /// <summary>
        /// グラフカットに基づくアルゴリズムにより視差画像を計算する (cvFindStereoCorrespondenceGC)
        /// </summary>
        /// <param name="left">左画像．シングルチャンネル，8ビット．</param>
        /// <param name="right">右画像．左画像と同じサイズ，同じ種類．</param>
        /// <param name="dispLeft">出力オプション：シングルチャンネル，16ビット，符号有り整数．入力画像と同じサイズの左視差画像． </param>
        /// <param name="dispRight">出力オプション：シングルチャンネル，16ビット，符号有り整数．入力画像と同じサイズの右視差画像． </param>
#else
        /// <summary>
        /// Computes the disparity map using graph cut-based algorithm (cvFindStereoCorrespondenceGC)
        /// </summary>
        /// <param name="left">The left single-channel, 8-bit image. </param>
        /// <param name="right">The right image of the same size and the same type. </param>
        /// <param name="dispLeft">The optional output single-channel 16-bit signed left disparity map of the same size as input images. </param>
        /// <param name="dispRight">The optional output single-channel 16-bit signed right disparity map of the same size as input images. </param>
#endif
        public void FindStereoCorrespondence(CvArr left, CvArr right, CvArr dispLeft, CvArr dispRight)
        {
            Cv.FindStereoCorrespondenceGC(left, right, dispLeft, dispRight, this);
        }
#if LANG_JP
        /// <summary>
        /// グラフカットに基づくアルゴリズムにより視差画像を計算する (cvFindStereoCorrespondenceGC)
        /// </summary>
        /// <param name="left">左画像．シングルチャンネル，8ビット．</param>
        /// <param name="right">右画像．左画像と同じサイズ，同じ種類．</param>
        /// <param name="dispLeft">出力オプション：シングルチャンネル，16ビット，符号有り整数．入力画像と同じサイズの左視差画像． </param>
        /// <param name="dispRight">出力オプション：シングルチャンネル，16ビット，符号有り整数．入力画像と同じサイズの右視差画像． </param>
        /// <param name="useDisparityGuess">このパラメータが 0 でない場合， あらかじめ定義された視差画像を用いて計算が開始される．つまり， dispLeft と dispRight が共に，妥当な視差画像である必要がある． そうでない場合は，（すべてのピクセルがオクルージョンとなっている）空の視差画像から開始される．</param>
#else
        /// <summary>
        /// Computes the disparity map using graph cut-based algorithm (cvFindStereoCorrespondenceGC)
        /// </summary>
        /// <param name="left">The left single-channel, 8-bit image. </param>
        /// <param name="right">The right image of the same size and the same type. </param>
        /// <param name="dispLeft">The optional output single-channel 16-bit signed left disparity map of the same size as input images. </param>
        /// <param name="dispRight">The optional output single-channel 16-bit signed right disparity map of the same size as input images. </param>
        /// <param name="useDisparityGuess">If the parameter is not zero, the algorithm will start with pre-defined disparity maps. Both dispLeft and dispRight should be valid disparity maps. Otherwise, the function starts with blank disparity maps (all pixels are marked as occlusions). </param>
#endif
        public void FindStereoCorrespondence(CvArr left, CvArr right, CvArr dispLeft, CvArr dispRight, bool useDisparityGuess)
        {
            Cv.FindStereoCorrespondenceGC(left, right, dispLeft, dispRight, this, useDisparityGuess);
        }
        #endregion
    }
}
