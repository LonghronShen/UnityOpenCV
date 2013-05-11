﻿/*
 * (C) 2008-2012 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Drawing;
//using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// System.Drawing.BitmapとIplImageの相互変換メソッドを提供するクラス
    /// </summary>
#else
    /// <summary>
    /// static class which provides conversion between System.Drawing.Bitmap and IplImage
    /// </summary>
#endif
    public static class BitmapConverter
    {
        #region ToIplImage
#if LANG_JP
        /// <summary>
        /// System.Drawing.BitmapからOpenCVのIplImageへ変換して返す.
        /// </summary>
        /// <param name="src">変換するSystem.Drawing.Bitmap</param>
        /// <returns>変換結果のIplImage</returns>
#else
        /// <summary>
        /// Converts System.Drawing.Bitmap to IplImage
        /// </summary>
        /// <param name="src">System.Drawing.Bitmap object to be converted</param>
        /// <returns>An IplImage object which is converted from System.Drawing.Bitmap</returns>
#endif
//        public static IplImage ToIplImage(Bitmap src)
//        {
//            if (src == null)
//            {
//                throw new ArgumentNullException("src");
//            }
//            int w = src.Width;
//            int h = src.Height;
//            int channels;
//            switch (src.PixelFormat)
//            {
//                case PixelFormat.Format24bppRgb:
//                case PixelFormat.Format32bppRgb:
//                    channels = 3; break;
//                case PixelFormat.Format32bppArgb:
//                    channels = 4; break;
//                case PixelFormat.Format8bppIndexed:
//                case PixelFormat.Format1bppIndexed:
//                    channels = 1; break;
//                default:
//                    throw new NotImplementedException();
//            }
//            IplImage dst = Cv.CreateImage(new CvSize(w, h), BitDepth.U8, channels);
//            ToIplImage(src, dst);
//            return dst;
//        }

#if LANG_JP
        /// <summary>
        /// System.Drawing.BitmapからOpenCVのIplImageへ変換して返す.
        /// </summary>
        /// <param name="src">変換するSystem.Drawing.Bitmap</param>
        /// <param name="dst">変換結果を格納するIplImage</param>
#else
        /// <summary>
        /// Converts System.Drawing.Bitmap to IplImage
        /// </summary>
        /// <param name="src">System.Drawing.Bitmap object to be converted</param>
        /// <param name="dst">An IplImage object which is converted from System.Drawing.Bitmap</param>
#endif
//        public static void ToIplImage(Bitmap src, IplImage dst)
//        {
//            if (src == null)
//                throw new ArgumentNullException("src");
//            if (dst == null)
//                throw new ArgumentNullException("dst");
//            if (dst.IsDisposed)
//                throw new ArgumentException("The specified dst is disposed.", "dst");
//            if (dst.Depth != BitDepth.U8)
//                throw new NotSupportedException();
//            if (src.Width != dst.Width || src.Height != dst.Height)
//                throw new ArgumentException("Size of src must be equal to size of dst.");
//
//            int w = src.Width;
//            int h = src.Height;
//
//            Rectangle rect = new Rectangle(0, 0, w, h);
//            BitmapData bd = src.LockBits(rect, ImageLockMode.ReadOnly, src.PixelFormat);
//
//            unsafe
//            {
//                byte* p = (byte*)bd.Scan0.ToPointer();
//                int stride = bd.Stride;
//                int offset = stride - (w / 8);
//                int widthStep = dst.WidthStep;
//                byte* imageData = (byte*)dst.ImageData.ToPointer();
//
//                switch (src.PixelFormat)
//                {
//                    case PixelFormat.Format1bppIndexed:
//                        {
//                            if (dst.NChannels != 1)
//                            {
//                                throw new ArgumentException("Invalid nChannels");
//                            }
//                            int x = 0;
//                            int y;
//                            int byte_pos;
//                            byte b;
//                            int i;
//                            for (y = 0; y < h; y++)
//                            {
//                                // 横は必ず4byte幅に切り上げられる。
//                                // この行の各バイトを調べていく
//                                for (byte_pos = 0; byte_pos < stride; byte_pos++)
//                                {
//                                    if (x < w)
//                                    {
//                                        // 現在の位置のバイトからそれぞれのビット8つを取り出す
//                                        b = p[byte_pos];
//                                        for (i = 0; i < 8; i++)
//                                        {
//                                            if (x >= w)
//                                            {
//                                                break;
//                                            }
//                                            // IplImageは8bit/pixel
//                                            imageData[widthStep * y + x] = ((b & 0x80) == 0x80) ? (byte)255 : (byte)0;
//                                            b <<= 1;
//                                            x++;
//                                        }
//                                    }
//                                }
//                                // 次の行へ
//                                x = 0;
//                                p += stride;
//                            }
//                        }
//                        break;
//                    case PixelFormat.Format8bppIndexed:
//                        {
//                            if (dst.NChannels != 1)
//                            {
//                                throw new ArgumentException("Invalid nChannels");
//                            }
//                            /*for (int y = 0; y < h; y++)
//                            {
//                                for (int x = 0; x < w; x++)
//                                {
//                                    imageData[y * widthStep + x] = p[y * stride + x];
//                                }
//                            }*/
//                            Util.CopyMemory(dst.ImageData, bd.Scan0, dst.ImageSize);
//                        }
//                        break;
//                    case PixelFormat.Format24bppRgb:
//                        {
//                            if (dst.NChannels != 3)
//                            {
//                                throw new ArgumentException("Invalid nChannels");
//                            }
//                            /*for (int y = 0; y < h; y++)
//                            {
//                                for (int x = 0; x < w; x++)
//                                {
//                                    imageData[y * widthStep + x * 3] = p[y * stride + x * 3];
//                                    imageData[y * widthStep + x * 3 + 1] = p[y * stride + x * 3 + 1];
//                                    imageData[y * widthStep + x * 3 + 2] = p[y * stride + x * 3 + 2];
//                                }
//                            }*/
//                            Util.CopyMemory(dst.ImageData, bd.Scan0, dst.ImageSize);
//                        }
//                        break;
//                    case PixelFormat.Format32bppRgb:
//                    case PixelFormat.Format32bppArgb:
//                        {
//                            switch (dst.NChannels)
//                            {
//                                case 4:
//                                    Util.CopyMemory(dst.ImageData, bd.Scan0, dst.ImageSize);
//                                    break;
//                                case 3:
//                                    for (int y = 0; y < h; y++)
//                                    {
//                                        for (int x = 0; x < w; x++)
//                                        {
//                                            imageData[y * widthStep + x * 3] = p[y * stride + x * 4 + 0];
//                                            imageData[y * widthStep + x * 3 + 1] = p[y * stride + x * 4 + 1];
//                                            imageData[y * widthStep + x * 3 + 2] = p[y * stride + x * 4 + 2];
//                                        }
//                                    }
//                                    break;
//                                default:
//                                    throw new ArgumentException("Invalid nChannels");
//                            }                            
//                        }
//                        break;
//                }
//            }
//            src.UnlockBits(bd);
//        }
        #endregion

        #region ToBitmap
#if LANG_JP
        /// <summary>
        /// OpenCVのIplImageをSystem.Drawing.Bitmapに変換する
        /// </summary>
        /// <param name="src">変換するIplImage</param>
        /// <returns>System.Drawing.Bitmap</returns>
#else
        /// <summary>
        /// Converts IplImage to System.Drawing.Bitmap
        /// </summary>
        /// <param name="src">System.Drawing.Bitmap</param>
        /// <returns></returns>
#endif
//        public static Bitmap ToBitmap(IplImage src)
//        {
//            if (src == null)
//            {
//                throw new ArgumentNullException("src");
//            }
//            PixelFormat pf;
//            switch (src.NChannels)
//            {
//                case 1:
//                    pf = PixelFormat.Format8bppIndexed; break;
//                case 3:
//                    pf = PixelFormat.Format24bppRgb; break;
//                case 4:
//                    pf = PixelFormat.Format32bppArgb; break;
//                default:
//                    throw new ArgumentOutOfRangeException("Number of channels must be 1, 3 or 4.");
//            }
//            return ToBitmap(src, pf);
//        }
#if LANG_JP
        /// <summary>
        /// OpenCVのIplImageをSystem.Drawing.Bitmapに変換する
        /// </summary>
        /// <param name="src">変換するIplImage</param>
        /// <param name="pf">ピクセル深度</param>
        /// <returns>System.Drawing.Bitmap</returns>
#else
        /// <summary>
        /// Converts IplImage to System.Drawing.Bitmap
        /// </summary>
        /// <param name="src">System.Drawing.Bitmap</param>
        /// <param name="pf">Pixel Depth</param>
        /// <returns></returns>
#endif
//        public static Bitmap ToBitmap(IplImage src, PixelFormat pf)
//        {
//            if (src == null)
//            {
//                throw new ArgumentNullException("src");
//            }
//            if (src.Depth != BitDepth.U8)
//            {
//                //throw new ArgumentOutOfRangeException("Depth of the image must be BitDepth.U8");
//            }
//            Bitmap bitmap = new Bitmap(src.ROI.Width, src.ROI.Height, pf);
//            ToBitmap(src, bitmap);
//            return bitmap;
//        }

#if LANG_JP
        /// <summary>
        /// OpenCVのIplImageを指定した出力先にSystem.Drawing.Bitmapとして変換する
        /// </summary>
        /// <param name="src">変換するIplImage</param>
        /// <param name="dst">出力先のSystem.Drawing.Bitmap</param>
        /// <remarks>Author: Schima, Gummo (ROI support)</remarks>
#else
        /// <summary>
        /// Converts IplImage to System.Drawing.Bitmap
        /// </summary>
        /// <param name="src">System.Drawing.Bitmap</param>
        /// <param name="dst">IplImage</param>
        /// <remarks>Author: Schima, Gummo (ROI support)</remarks>
#endif
//        public static void ToBitmap(IplImage src, Bitmap dst)
//        {
//            if (src == null)
//                throw new ArgumentNullException("src");
//            if (dst == null)
//                throw new ArgumentNullException("dst");
//            if (src.IsDisposed)
//                throw new ArgumentException("The image is disposed.", "src");
//            //if (src.Depth != BitDepth.U8)
//            //    throw new ArgumentOutOfRangeException("src");
//            if (src.ROI.Width != dst.Width || src.ROI.Height != dst.Height)
//                throw new ArgumentException("");
//
//            PixelFormat pf = dst.PixelFormat;
//
//            // 1プレーン用の場合、グレースケールのパレット情報を生成する
//            if (pf == PixelFormat.Format8bppIndexed)
//            {
//                ColorPalette plt = dst.Palette;
//                for (int x = 0; x < 256; x++)
//                {
//                    plt.Entries[x] = Color.FromArgb(x, x, x);
//                }
//                dst.Palette = plt;
//            }
//
//            // BitDepth.U8以外の場合はスケーリングする
//            IplImage _src;
//            if (src.Depth != BitDepth.U8)
//            {
//                _src = new IplImage(src.Size, BitDepth.U8, src.NChannels);
//                using (IplImage f = src.Clone())
//                {
//                    if (src.Depth == BitDepth.F32 || src.Depth == BitDepth.F64)
//                    {
//                        Cv.Normalize(src, f, 255, 0, NormType.MinMax);
//                    }
//                    Cv.ConvertScaleAbs(f, _src);
//                }
//            }
//            else
//            {
//                _src = src;
//            }
//            Bitmap _dst = dst;
//
//            unsafe
//            {
//                int w = _src.ROI.Width;
//                int h = _src.ROI.Height;
//                Rectangle rect = new Rectangle(0, 0, w, h);
//                BitmapData bd = _dst.LockBits(rect, ImageLockMode.WriteOnly, pf);
//                byte* psrc = (byte*)(_src.ImageData.ToPointer());
//                byte* pdst = (byte*)(bd.Scan0.ToPointer());
//                int xo = _src.ROI.X;
//                int yo = _src.ROI.Y;
//                int widthStep_src = _src.WidthStep;
//                int widthStep_dst = ((_src.ROI.Width * _src.NChannels) + 3) / 4 * 4;    // 4の倍数に揃える
//                int stride = bd.Stride;
//                int ch = _src.NChannels;
//
//                switch (pf)
//                {
//                    case PixelFormat.Format1bppIndexed:
//                        {
//                            // BitmapDataは4byte幅だが、IplImageは1byte幅
//                            // 手作業で移し替える				 
//                            int offset = stride - (w / 8);
//                            int x = xo;
//                            int y;
//                            int byte_pos;
//                            byte mask;
//                            byte b = 0;
//                            int i;
//                            for (y = yo; y < h; y++)
//                            {
//                                for (byte_pos = 0; byte_pos < stride; byte_pos++)
//                                {
//                                    if (x < w)
//                                    {
//                                        for (i = 0; i < 8; i++)
//                                        {
//                                            mask = (byte)(0x80 >> i);
//                                            if (x < w && psrc[widthStep_src * y + x] == 0)
//                                                b &= (byte)(mask ^ 0xff);
//                                            else
//                                                b |= mask;
//
//                                            x++;
//                                        }
//                                        pdst[byte_pos] = b;
//                                    }
//                                }
//                                x = xo;
//                                pdst += stride;
//                            }
//                            break;
//                        }
//
//                    case PixelFormat.Format8bppIndexed:
//                    case PixelFormat.Format24bppRgb:
//                    case PixelFormat.Format32bppArgb:
//                        if (widthStep_src == widthStep_dst)
//                        {
//                            Util.CopyMemory(pdst, psrc, _src.ImageSize);
//                        }
//                        else
//                        {
//                            for (int y = 0; y < h; y++)
//                            {
//                                int offset_src = ((y + yo) * widthStep_src) + xo;
//                                int offset_dst = (y * widthStep_dst);
//
//                                /*
//                                for (int x = 0; x < _src.ROI.Width; x++)
//                                {
//                                    pdst[x + offset_dst] = psrc[x + offset_src];
//                                }
//                                //*/
//                                // 一列ごとにコピー
//                                Util.CopyMemory(pdst + offset_dst, psrc + offset_src, w * ch);
//                            }
//                        }
//                        break;
//
//                    default:
//                        throw new NotImplementedException();
//                }
//
//                _dst.UnlockBits(bd);
//                // 反転対策
//                if (src.Origin == ImageOrigin.BottomLeft)
//                {
//                    _dst.RotateFlip(RotateFlipType.RotateNoneFlipY);
//                }
//
//
//                // スケーリングのために余分に作ったインスタンスの破棄
//                if (_src != src)
//                {
//                    _src.Dispose();
//                }
//            }
//        }
        #endregion

        #region DrawToHDC
        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="hdc"></param>
        /// <param name="dstRect"></param>
        public static void DrawToHdc(IplImage img, IntPtr hdc, CvRect dstRect) 
        {
            if (Platform.OS == OS.Unix)
            {
                throw new PlatformNotSupportedException("This method is only for Windows.");
            }

            if(img == null)
                throw new ArgumentNullException("img");
            if (hdc == IntPtr.Zero)
                throw new ArgumentNullException("hdc");
            if( img.Depth != BitDepth.U8)
                throw new NotSupportedException();

            int bmpW = img.Width;
            int bmpH = img.Height;
            CvRect roi = Cv.GetImageROI( img );

            unsafe{
                int headerSize = sizeof(Win32API.BITMAPINFOHEADER) + 1024;
                IntPtr buffer = Marshal.AllocHGlobal(headerSize);
                Win32API.BITMAPINFO bmi = (Win32API.BITMAPINFO)Marshal.PtrToStructure(buffer, typeof(Win32API.BITMAPINFO));

                if(roi.Width == dstRect.Width && roi.Height == dstRect.Height)
                {
                    DrawToHdc(img, hdc, dstRect.X, dstRect.Y, dstRect.Width, dstRect.Height, roi.X, roi.Y);
                    return;
                }
    
                if(roi.Width > dstRect.Width)
                {
                    Win32API.SetStretchBltMode(hdc, Win32API.HALFTONE);
                }
                else
                {
                    Win32API.SetStretchBltMode(hdc, Win32API.COLORONCOLOR);
                }

                FillBitmapInfo(ref bmi, bmpW, bmpH, img.Bpp, (int)img.Origin);

                Win32API.StretchDIBits(
                    hdc,
                    dstRect.X, dstRect.Y, dstRect.Width, dstRect.Height,
                    roi.X, roi.Y, roi.Width, roi.Height,
                    img.ImageData, ref bmi, Win32API.DIB_RGB_COLORS, Win32API.SRCCOPY);

                Marshal.FreeHGlobal(buffer);
            }
        }    

        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="hdc"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="from_x"></param>
        /// <param name="from_y"></param>
        public static void DrawToHdc(IplImage img, IntPtr hdc, int x, int y, int w, int h, int from_x, int from_y)
        {
            if (Platform.OS == OS.Unix)
            {
                throw new PlatformNotSupportedException("This method is only for Windows.");
            }

            if(img == null)
                throw new ArgumentNullException("img");
            if (hdc == IntPtr.Zero)
                throw new ArgumentNullException("hdc");
            if( img.Depth != BitDepth.U8 )
                throw new NotSupportedException();

            int bmpW = img.Width;
            int bmpH = img.Height;

            unsafe
            {
                int headerSize = sizeof(Win32API.BITMAPINFOHEADER) + 1024;
                IntPtr buffer = Marshal.AllocHGlobal(headerSize);
                Win32API.BITMAPINFO bmi = (Win32API.BITMAPINFO)Marshal.PtrToStructure(buffer, typeof(Win32API.BITMAPINFO));

                FillBitmapInfo(ref bmi, bmpW, bmpH, img.Bpp, (int)img.Origin);

                from_x = Math.Min(Math.Max(from_x, 0), bmpW - 1);
                from_y = Math.Min(Math.Max(from_y, 0), bmpH - 1);

                uint sw = (uint)Math.Max(Math.Min(bmpW - from_x, w), 0);
                uint sh = (uint)Math.Max(Math.Min(bmpH - from_y, h), 0);

                Win32API.SetDIBitsToDevice(
                    hdc, x, y, sw, sh, from_x, from_y, (uint)from_y, sh,
                    new IntPtr(img.ImageData.ToInt32() + from_y*img.WidthStep),
                    ref bmi, Win32API.DIB_RGB_COLORS);

                Marshal.FreeHGlobal(buffer);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="g"></param>
        /// <param name="dstRect"></param>
//        public static void DrawToGraphics(IplImage img, Graphics g, CvRect dstRect) 
//        {
//            if (Platform.OS == OS.Unix)
//            {
//                throw new PlatformNotSupportedException("This method is only for Windows.");
//            }
//
//            IntPtr hdc = g.GetHdc();
//            DrawToHdc(img, hdc, dstRect);
//            g.ReleaseHdc(hdc);
//        }    

        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="from_x"></param>
        /// <param name="from_y"></param>
//        public static void DrawToGraphics(IplImage img, Graphics g, int x, int y, int w, int h, int from_x, int from_y)
//        {
//            if (Platform.OS == OS.Unix)
//            {
//                throw new PlatformNotSupportedException("This method is only for Windows.");
//            }
//
//            IntPtr hdc = g.GetHdc();
//            DrawToHdc(img, hdc, x, y, w, h, from_x, from_y);
//            g.ReleaseHdc(hdc);
//        }

        private static unsafe void FillBitmapInfo(ref Win32API.BITMAPINFO bmi, int width, int height, int bpp, int origin)
        {
            Debug.Assert(width > 0 && height > 0 && (bpp == 8 || bpp == 24 || bpp == 32));

            Win32API.BITMAPINFOHEADER bmih = bmi.Header;
            using (ScopedGCHandle handle = new ScopedGCHandle(bmih, GCHandleType.Pinned))
            {
                //Win32API.FillMemory(handle.AddrOfPinnedObject(), Marshal.SizeOf(typeof(Win32API.BITMAPINFOHEADER)), 0);
                bmih.Size = (uint)sizeof(Win32API.BITMAPINFOHEADER);
                bmih.Width = width;
                bmih.Height = (origin != 0) ? Math.Abs(height) : -Math.Abs(height);
                bmih.Planes = 1;
                bmih.BitCount = (ushort)bpp;
                bmih.Compression = Win32API.BI_RGB;
                bmih.ClrImportant = 0;
                bmih.Compression = 0;
                bmih.SizeImage = 0;
                bmih.XPelsPerMeter = 0;
                bmih.YPelsPerMeter = 0;
                bmi.Header = bmih;
            }

            if (bpp == 8)
            {
                Win32API.RGBQUAD[] palette = bmi.Colors;
                for (int i = 0; i < palette.Length; i++)
                {
                    palette[i].Blue = palette[i].Green = palette[i].Red = (byte)i;
                    palette[i].Reserved = 0;
                }
                bmi.Colors = palette;
            }
        }
        #endregion
    }
}
