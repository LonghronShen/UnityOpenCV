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
    /// MSERのパラメータ
    /// </summary>
#else
    /// <summary>
    /// Various MSER algorithm parameters
    /// </summary>
#endif
    [Serializable]
    public class CvMSERParams : ICloneable
    {
        /// <summary>
        /// Field data
        /// </summary>
        protected WCvMSERParams _p;

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
        internal WCvMSERParams Struct
        {
            get { return _p; }
        }

#if LANG_JP
        /// <summary>
        /// delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}
        /// </summary>
#else
        /// <summary>
        /// delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}
        /// </summary>
#endif
        public int Delta
        {
            get { return _p.delta; }
            set { _p.delta = value; }
        }

#if LANG_JP
        /// <summary>
        /// prune the area which bigger than max_area
        /// </summary>
#else
        /// <summary>
        /// prune the area which bigger than max_area
        /// </summary>
#endif
        public int MaxArea
        {
            get { return _p.maxArea; }
            set { _p.maxArea = value; }
        }

#if LANG_JP
        /// <summary>
        /// prune the area which smaller than min_area
        /// </summary>
#else
        /// <summary>
        /// prune the area which smaller than min_area
        /// </summary>
#endif
        public int MinArea
        {
            get { return _p.minArea; }
            set { _p.minArea = value; }
        }

#if LANG_JP
        /// <summary>
        /// prune the area have simliar size to its children
        /// </summary>
#else
        /// <summary>
        /// prune the area have simliar size to its children
        /// </summary>
#endif
        public float MaxVariation
        {
            get { return _p.maxVariation; }
            set { _p.maxVariation = value; }
        }

#if LANG_JP
        /// <summary>
        /// trace back to cut off mser with diversity &lt; min_diversity
        /// </summary>
#else
        /// <summary>
        /// trace back to cut off mser with diversity &lt; min_diversity
        /// </summary>
#endif
        public float MinDiversity
        {
            get { return _p.minDiversity; }
            set { _p.minDiversity = value; }
        }

#if LANG_JP
        /// <summary>
        /// for color image, the evolution steps
        /// </summary>
#else
        /// <summary>
        /// for color image, the evolution steps
        /// </summary>
#endif
        public int MaxEvolution
        {
            get { return _p.maxEvolution; }
            set { _p.maxEvolution = value; }
        }

#if LANG_JP
        /// <summary>
        /// the area threshold to cause re-initialize
        /// </summary>
#else
        /// <summary>
        /// the area threshold to cause re-initialize
        /// </summary>
#endif
        public double AreaThreshold
        {
            get { return _p.areaThreshold; }
            set { _p.areaThreshold = value; }
        }

#if LANG_JP
        /// <summary>
        /// ignore too small margin
        /// </summary>
#else
        /// <summary>
        /// ignore too small margin
        /// </summary>
#endif
        public double MinMargin
        {
            get { return _p.minMargin; }
            set { _p.minMargin = value; }
        }

#if LANG_JP
        /// <summary>
        /// the aperture size for edge blur
        /// </summary>
#else
        /// <summary>
        /// the aperture size for edge blur
        /// </summary>
#endif
        public int EdgeBlurSize
        {
            get { return _p.edgeBlurSize; }
            set { _p.edgeBlurSize = value; }
        }
        #endregion

        #region Constructors
#if LANG_JP
        /// <summary>
        /// MSERのパラメータを生成する
        /// </summary>
#else
        /// <summary>
        /// Creates MSER parameters
        /// </summary>
#endif
        public CvMSERParams()
            : this(5, 60, 14400, 0.25f, 0.2f, 200, 1.01, 0.003, 5)
        {
        }
#if LANG_JP
        /// <summary>
        /// MSERのパラメータを生成する
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
#else
        /// <summary>
        /// Creates MSER parameters
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
#endif
        public CvMSERParams(int delta)
            : this(delta, 60, 14400, 0.25f, 0.2f, 200, 1.01, 0.003, 5)
        {
        }
#if LANG_JP
        /// <summary>
        /// MSERのパラメータを生成する
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="min_area">prune the area which smaller than min_area</param>
#else
        /// <summary>
        /// Creates MSER parameters
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="min_area">prune the area which smaller than min_area</param>
#endif
        public CvMSERParams(int delta, int min_area)
            : this(delta, min_area, 14400, 0.25f, 0.2f, 200, 1.01, 0.003, 5)
        {
        }
#if LANG_JP
        /// <summary>
        /// MSERのパラメータを生成する
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="min_area">prune the area which smaller than min_area</param>
        /// <param name="max_area">prune the area which bigger than max_area</param>
#else
        /// <summary>
        /// Creates MSER parameters
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="min_area">prune the area which smaller than min_area</param>
        /// <param name="max_area">prune the area which bigger than max_area</param>
#endif
        public CvMSERParams(int delta, int min_area, int max_area)
            : this(delta, min_area, max_area, 0.25f, 0.2f, 200, 1.01, 0.003, 5)
        {
        }
#if LANG_JP
        /// <summary>
        /// MSERのパラメータを生成する
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="min_area">prune the area which smaller than min_area</param>
        /// <param name="max_area">prune the area which bigger than max_area</param>
        /// <param name="max_variation">prune the area have simliar size to its children</param>
#else
        /// <summary>
        /// Creates MSER parameters
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="min_area">prune the area which smaller than min_area</param>
        /// <param name="max_area">prune the area which bigger than max_area</param>
        /// <param name="max_variation">prune the area have simliar size to its children</param>
#endif
        public CvMSERParams(int delta, int min_area, int max_area, float max_variation)
            : this(delta, min_area, max_area, max_variation, 0.2f, 200, 1.01, 0.003, 5)
        {
        }
#if LANG_JP
        /// <summary>
        /// MSERのパラメータを生成する
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="min_area">prune the area which smaller than min_area</param>
        /// <param name="max_area">prune the area which bigger than max_area</param>
        /// <param name="max_variation">prune the area have simliar size to its children</param>
        /// <param name="min_diversity">trace back to cut off mser with diversity &lt; min_diversity</param>
#else
        /// <summary>
        /// Creates MSER parameters
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="min_area">prune the area which smaller than min_area</param>
        /// <param name="max_area">prune the area which bigger than max_area</param>
        /// <param name="max_variation">prune the area have simliar size to its children</param>
        /// <param name="min_diversity">trace back to cut off mser with diversity &lt; min_diversity</param>
#endif
        public CvMSERParams(int delta, int min_area, int max_area, float max_variation, float min_diversity)
            : this(delta, min_area, max_area, max_variation, min_diversity, 200, 1.01, 0.003, 5)
        {
        }
#if LANG_JP
        /// <summary>
        /// MSERのパラメータを生成する
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="min_area">prune the area which smaller than min_area</param>
        /// <param name="max_area">prune the area which bigger than max_area</param>
        /// <param name="max_variation">prune the area have simliar size to its children</param>
        /// <param name="min_diversity">trace back to cut off mser with diversity &lt; min_diversity</param>
        /// <param name="max_evolution">for color image, the evolution steps</param>
#else
        /// <summary>
        /// Creates MSER parameters
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="min_area">prune the area which smaller than min_area</param>
        /// <param name="max_area">prune the area which bigger than max_area</param>
        /// <param name="max_variation">prune the area have simliar size to its children</param>
        /// <param name="min_diversity">trace back to cut off mser with diversity &lt; min_diversity</param>
        /// <param name="max_evolution">for color image, the evolution steps</param>
#endif
        public CvMSERParams(int delta, int min_area, int max_area, float max_variation, float min_diversity, int max_evolution)
            : this(delta, min_area, max_area, max_variation, min_diversity, max_evolution, 1.01, 0.003, 5)
        {
        }
#if LANG_JP
        /// <summary>
        /// MSERのパラメータを生成する
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="min_area">prune the area which smaller than min_area</param>
        /// <param name="max_area">prune the area which bigger than max_area</param>
        /// <param name="max_variation">prune the area have simliar size to its children</param>
        /// <param name="min_diversity">trace back to cut off mser with diversity &lt; min_diversity</param>
        /// <param name="max_evolution">for color image, the evolution steps</param>
        /// <param name="area_threshold">the area threshold to cause re-initialize</param>
#else
        /// <summary>
        /// Creates MSER parameters
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="min_area">prune the area which smaller than min_area</param>
        /// <param name="max_area">prune the area which bigger than max_area</param>
        /// <param name="max_variation">prune the area have simliar size to its children</param>
        /// <param name="min_diversity">trace back to cut off mser with diversity &lt; min_diversity</param>
        /// <param name="max_evolution">for color image, the evolution steps</param>
        /// <param name="area_threshold">the area threshold to cause re-initialize</param>
#endif
        public CvMSERParams(int delta, int min_area, int max_area, float max_variation, float min_diversity, int max_evolution, double area_threshold)
            : this(delta, min_area, max_area, max_variation, min_diversity, max_evolution, area_threshold, 0.003, 5)
        {
        }
#if LANG_JP
        /// <summary>
        /// MSERのパラメータを生成する
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="min_area">prune the area which smaller than min_area</param>
        /// <param name="max_area">prune the area which bigger than max_area</param>
        /// <param name="max_variation">prune the area have simliar size to its children</param>
        /// <param name="min_diversity">trace back to cut off mser with diversity &lt; min_diversity</param>
        /// <param name="max_evolution">for color image, the evolution steps</param>
        /// <param name="area_threshold">the area threshold to cause re-initialize</param>
        /// <param name="min_margin">ignore too small margin</param>
#else
        /// <summary>
        /// Creates MSER parameters
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="min_area">prune the area which smaller than min_area</param>
        /// <param name="max_area">prune the area which bigger than max_area</param>
        /// <param name="max_variation">prune the area have simliar size to its children</param>
        /// <param name="min_diversity">trace back to cut off mser with diversity &lt; min_diversity</param>
        /// <param name="max_evolution">for color image, the evolution steps</param>
        /// <param name="area_threshold">the area threshold to cause re-initialize</param>
        /// <param name="min_margin">ignore too small margin</param>
#endif
        public CvMSERParams(int delta, int min_area, int max_area, float max_variation, float min_diversity, int max_evolution, double area_threshold, double min_margin)
            : this(delta, min_area, max_area, max_variation, min_diversity, max_evolution, area_threshold, min_margin, 5)
        {
        }
#if LANG_JP
        /// <summary>
        /// MSERのパラメータを生成する
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="min_area">prune the area which smaller than min_area</param>
        /// <param name="max_area">prune the area which bigger than max_area</param>
        /// <param name="max_variation">prune the area have simliar size to its children</param>
        /// <param name="min_diversity">trace back to cut off mser with diversity &lt; min_diversity</param>
        /// <param name="max_evolution">for color image, the evolution steps</param>
        /// <param name="area_threshold">the area threshold to cause re-initialize</param>
        /// <param name="min_margin">ignore too small margin</param>
        /// <param name="edge_blur_size">the aperture size for edge blur</param>
#else
        /// <summary>
        /// Creates MSER parameters
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="min_area">prune the area which smaller than min_area</param>
        /// <param name="max_area">prune the area which bigger than max_area</param>
        /// <param name="max_variation">prune the area have simliar size to its children</param>
        /// <param name="min_diversity">trace back to cut off mser with diversity &lt; min_diversity</param>
        /// <param name="max_evolution">for color image, the evolution steps</param>
        /// <param name="area_threshold">the area threshold to cause re-initialize</param>
        /// <param name="min_margin">ignore too small margin</param>
        /// <param name="edge_blur_size">the aperture size for edge blur</param>
#endif
        public CvMSERParams(int delta, int min_area, int max_area, float max_variation, float min_diversity, int max_evolution, double area_threshold, double min_margin, int edge_blur_size)
        {
            _p = CvInvoke.cvMSERParams(delta, min_area, max_area, max_variation, min_diversity, max_evolution, area_threshold, min_margin, edge_blur_size);
        }
        #endregion

        #region ICloneable Members
#if LANG_JP
        /// <summary>
        /// 現在のインスタンスのコピーである新しいオブジェクトを作成します。    
        /// </summary>
        /// <returns>このインスタンスのコピーである新しいオブジェクト。</returns>
#else
        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
#endif
        public CvMSERParams Clone()
        {
            return (CvMSERParams)MemberwiseClone();
        }
        object ICloneable.Clone()
        {
            return Clone();
        }
        #endregion
    }
}
