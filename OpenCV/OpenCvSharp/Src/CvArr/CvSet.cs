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
    /// ノードの集合
    /// </summary>
#else
    /// <summary>
    /// Collection of nodes
    /// </summary>
#endif
    public class CvSet : CvSeq
    {
        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 既定の初期化
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        protected CvSet()
            : base()
        {
            this._ptr = IntPtr.Zero;
        }
#if LANG_JP
        /// <summary>
        /// 空のセットを生成する
        /// </summary>
        /// <param name="set_flags">生成するセットのタイプ． </param>
        /// <param name="header_size">セットのヘッダのサイズ（sizeof(CvSet)以上）． </param>
        /// <param name="elem_size">セットの要素のサイズ（CvSetElem 以上）． </param>
        /// <param name="storage">セットのためのコンテナ． </param>
#else
        /// <summary>
        /// Creates empty set
        /// </summary>
        /// <param name="set_flags">Type of the created set. </param>
        /// <param name="header_size">Set header size; may not be less than sizeof(CvSet). </param>
        /// <param name="elem_size">Set element size; may not be less than CvSetElem. </param>
        /// <param name="storage">Container for the set. </param>
#endif
        public CvSet(SeqType set_flags, int header_size, int elem_size, CvMemStorage storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException();
            }
            IntPtr ptr = CvInvoke.cvCreateSet(set_flags, header_size, elem_size, storage.CvPtr);
            Initialize(ptr);
            this._storage = storage;
        }

#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvSet*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr">struct CvSet*</param>
#endif
        public CvSet(IntPtr ptr)
        {
            Initialize(ptr);
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvSet*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr">struct CvSet*</param>
#endif
        protected override void Initialize(IntPtr ptr)
        {
            base.Initialize(ptr);
            this._ptr = ptr;
        }

        #endregion


        #region Properties
        /// <summary>
        /// sizeof(CvSet)
        /// </summary>
        new public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvSet));

#if LANG_JP
        /// <summary>
		/// 空きノードのリスト 
        /// </summary>
#else
        /// <summary>
        /// list of free nodes
        /// </summary>
#endif
        public CvSetElem FreeElems
        {
            get 
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WCvSet*)_ptr)->free_elems);

                    if (p != IntPtr.Zero)
                        return new CvSetElem(p);
                    else
                        return null;
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
        public int ActiveCount
        {
            get
            {
                unsafe
                {
                    return ((WCvSet*)_ptr)->active_count;
                }
            }
        }
        #endregion


        #region Methods
        #region ClearSet
#if LANG_JP
        /// <summary>
        /// セットをクリアする
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Clears set
        /// </summary>
        /// <returns>The function cvClearSet removes all elements from set. It has O(1) time complexity.</returns>
#endif
        public void ClearSet()
        {
            Cv.ClearSet(this);
        }
        #endregion
        #region GetSetElem
#if LANG_JP
        /// <summary>
        /// インデックスによってセットの要素を検索する
        /// </summary>
        /// <param name="index">シーケンスの中のセットの要素のインデックス．</param>
        /// <returns>見つけた要素への参照</returns>
#else
        /// <summary>
        /// Finds set element by its index
        /// </summary>
        /// <param name="index">Index of the set element within a sequence. </param>
        /// <returns>the pointer to it or null if the index is invalid or the corresponding node is free.</returns>
#endif
        public CvSetElem GetSetElem(int index)
        {
            return Cv.GetSetElem(this, index);
        }
        #endregion
        #region SetAdd
#if LANG_JP
        /// <summary>
        /// セットに新しいノード（要素）を追加する
        /// </summary>
        /// <returns>ノードへのインデックス</returns>
#else
        /// <summary>
        /// Occupies a node in the set
        /// </summary>
        /// <returns>the index to the node</returns>
#endif
        public int SetAdd()
        {
            return Cv.SetAdd(this);
        }
#if LANG_JP
        /// <summary>
        /// セットに新しいノード（要素）を追加する
        /// </summary>
        /// <param name="elem">挿入する要素． nullでない場合，新たに確保したノードにデータをコピーする （コピーした後，先頭の整数フィールドの最上位ビットはクリアされる）． </param>
        /// <returns>ノードへのインデックス</returns>
#else
        /// <summary>
        /// Occupies a node in the set
        /// </summary>
        /// <param name="elem">Optional input argument, inserted element. If not null, the function copies the data to the allocated node (The MSB of the first integer field is cleared after copying). </param>
        /// <returns>the index to the node</returns>
#endif
        public int SetAdd(CvSetElem elem)
        {
            return Cv.SetAdd(this, elem);
        }
#if LANG_JP
        /// <summary>
        /// セットに新しいノード（要素）を追加する
        /// </summary>
        /// <param name="elem">挿入する要素． nullでない場合，新たに確保したノードにデータをコピーする （コピーした後，先頭の整数フィールドの最上位ビットはクリアされる）． </param>
        /// <param name="inserted_elem">割り当てられた要素への参照</param>
        /// <returns>ノードへのインデックス</returns>
#else
        /// <summary>
        /// Occupies a node in the set
        /// </summary>
        /// <param name="elem">Optional input argument, inserted element. If not null, the function copies the data to the allocated node (The MSB of the first integer field is cleared after copying). </param>
        /// <param name="inserted_elem">Optional output argument; the pointer to the allocated cell. </param>
        /// <returns>the index to the node</returns>
#endif
        public int SetAdd(CvSetElem elem, out CvSetElem inserted_elem)
        {
            return Cv.SetAdd(this, elem, out inserted_elem);
        }
        #endregion
        #region SetNew
#if LANG_JP
        /// <summary>
        /// セットに要素を加える（高速版）
        /// </summary>
        /// <returns>ノードへのポインタ</returns>
#else
        /// <summary>
        /// Adds element to set (fast variant)
        /// </summary>
        /// <returns>pointer to a new node</returns>
#endif
        public CvSetElem SetNew()
        {
            return Cv.SetNew(this);
        }
        #endregion
        #region SetRemove
#if LANG_JP
        /// <summary>
        /// セットから要素を削除する
        /// </summary>
        /// <param name="index">削除する要素のインデックス．</param>
#else
        /// <summary>
        /// Removes element from set
        /// </summary>
        /// <param name="index">Index of the removed element. </param>
#endif
        public void SetRemove(int index)
        {
            Cv.SetRemove(this, index);
        }
        #endregion
        #region SetRemoveByPtr
#if LANG_JP
        /// <summary>
        /// ポインタで指定したセットの要素を削除する
        /// </summary>
        /// <param name="elem">削除される要素．</param>
#else
        /// <summary>
        /// Removes set element given its pointer
        /// </summary>
        /// <param name="elem">Removed element. </param>
#endif
        public void SetRemoveByPtr(IntPtr elem)
        {
            Cv.SetRemoveByPtr(this, elem);
        }
        #endregion
        #endregion
    }
}
