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
    /// cvMatchContourTrees�ŗp����A�ގ��x
    /// </summary>
#else
    /// <summary>
    /// Similarity measure (cvMatchContourTrees)
    /// </summary>
#endif
    public enum ContourTreesMatchMethod : int
    {
#if LANG_JP
        /// <summary>
        /// [CV_CONTOUR_TREES_MATCH_I1]
        /// </summary>
#else
        /// <summary>
        /// [CV_CONTOUR_TREES_MATCH_I1]
        /// </summary>
#endif
        I1 = CvConst.CV_CONTOUR_TREES_MATCH_I1,
    }
}