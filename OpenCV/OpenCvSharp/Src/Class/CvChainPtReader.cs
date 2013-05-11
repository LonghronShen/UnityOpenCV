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
    /// <summary>
    /// Chain Reader
    /// </summary>
    public class CvChainPtReader : CvSeqReader<CvPoint>, IEnumerable<CvPoint>, ICvPtrHolder
    {
        /// <summary>
        /// Target chain
        /// </summary>
        private CvChain _chain;

        
        #region Initialization and Disposal
#if LANG_JP
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public CvChainPtReader()
        {
            this._ptr = base.AllocMemory(SizeOf);
            this._chain = null;
        }
#if LANG_JP
        /// <summary>
        /// cvStartReadChainPointsで初期化
        /// </summary>
        /// <param name="chain">チェーンへのポインタ</param>
#else
        /// <summary>
        /// Initialize by cvStartReadChainPoints
        /// </summary>
        /// <param name="chain">Pointer to chain</param>
#endif
        public CvChainPtReader(CvChain chain)
            : this()
        {
            this._chain = chain;
            Cv.StartReadChainPoints(chain, this);
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
            // 親の解放処理
            base.Dispose(disposing);
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvChainPtReader)
        /// </summary>
        new public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvChainPtReader));
        /// <summary>
        /// Data pointer (CvChainPtReader*)
        /// </summary>
        new public IntPtr CvPtr
        {
            get { return _ptr; }
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
        public sbyte Code
        {
            get
            {
                unsafe
                {
                    return ((WCvChainPtReader*)_ptr)->code;
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
        public CvPoint Pt
        {
            get
            {
                unsafe
                {
                    return ((WCvChainPtReader*)_ptr)->pt;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// schar deltas[8][2]
        /// </summary>
#else
        /// <summary>
        /// schar deltas[8][2]
        /// </summary>
#endif
        public sbyte[,] Deltas
        {
            get 
            { 
                unsafe
                {
                    sbyte* src = ((WCvChainPtReader*)_ptr)->deltas;
                    sbyte[,] dst = new sbyte[8, 2];

                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            dst[i, j] = src[i * 2 + j];
                        }
                    }
                    return dst;
                }
            }
        }
        #endregion

        #region Methods
#if LANG_JP
        /// <summary>
        /// チェーンリーダを初期化する
        /// </summary>
        /// <param name="chain">チェーンへのポインタ</param>
#else
        /// <summary>
        /// Initializes chain reader
        /// </summary>
        /// <param name="chain">Pointer to chain</param>
#endif
        public void StartReadChainPoints(CvChain chain)
        {
            if (chain == null)
            {
                throw new ArgumentNullException("chain");
            }
            this._chain = chain;            
            CvInvoke.cvStartReadChainPoints(chain.CvPtr, this.CvPtr);
        }

        #region ReadChainPoint
#if LANG_JP
        /// <summary>
        /// チェーン上の次の点を得る
        /// </summary>
        /// <returns>現在のチェーン上の点</returns>
#else
        /// <summary>
        /// Gets next chain point
        /// </summary>
        /// <returns>Current chain point.</returns>
#endif
        public CvPoint ReadChainPoint()
        {
            return Cv.ReadChainPoint(this);
        }
        #endregion  
        #endregion


        #region IEnumerable<CvPoint>
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<CvPoint> GetEnumerator()
        {
            if (_chain == null)
            {
                throw new NotSupportedException();
            }
            Cv.StartReadChainPoints(_chain, this);

            CvSeq seq = Seq;
            if(seq == null)
            {
                throw new OpenCvSharpException();
            }

            int total = seq.Total;

            for (int i = 0; i < total; i++)
            {
                yield return Cv.ReadChainPoint(this);
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
