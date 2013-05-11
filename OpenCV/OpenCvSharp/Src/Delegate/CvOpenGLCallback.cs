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
    /// 
    /// </summary>
    /// <param name="userdata"></param>
    /// <returns></returns>
#else
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userdata"></param>
    /// <returns></returns>
#endif
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CvOpenGLCallback(IntPtr userdata);

}
