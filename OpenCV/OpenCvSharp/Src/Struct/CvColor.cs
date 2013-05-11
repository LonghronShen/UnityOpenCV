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
	/// 色をあらわす構造体.
	/// OpenCVのCvScalarや、System.Drawing.Colorとの暗黙の変換が定義されている.
	/// </summary>
#else
    /// <summary>
    /// Structure that represents RGB color (alias of CvScalar).
    /// </summary>
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct CvColor : IEquatable<CvColor>
    {
        #region Fields
#if LANG_JP
        /// <summary>
        /// R成分
        /// </summary>
#else
        /// <summary>
        /// Red
        /// </summary>
#endif
        public byte R;

#if LANG_JP
        /// <summary>
        /// G成分
        /// </summary>
#else
        /// <summary>
        /// Green
        /// </summary>
#endif
        public byte G;
        
#if LANG_JP
        /// <summary>
        /// B成分
        /// </summary>
#else
        /// <summary>
        /// Blue
        /// </summary>
#endif
        public byte B;
        #endregion

        #region Initializers
#if LANG_JP
        /// <summary>
        /// 初期化 
        /// </summary>
        /// <param name="r">R成分</param>
        /// <param name="g">G成分</param>
        /// <param name="b">B成分</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="r">Red</param>
        /// <param name="g">Green</param>
        /// <param name="b">Blue</param>
#endif
        public CvColor(byte r, byte g, byte b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }
#if LANG_JP
        /// <summary>
        /// 初期化 
        /// </summary>
        /// <param name="r">R成分</param>
        /// <param name="g">G成分</param>
        /// <param name="b">B成分</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="r">Red</param>
        /// <param name="g">Green</param>
        /// <param name="b">Blue</param>
#endif
        public CvColor(int r, int g, int b)
        {
            this.R = Convert.ToByte(r);
            this.G = Convert.ToByte(g);
            this.B = Convert.ToByte(b);
        }

#if LANG_JP
        /// <summary>
        /// ランダムな色を生成して返す
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates a random color
        /// </summary>
        /// <returns></returns>
#endif
        public static CvColor Random()
        {
            return new CvColor((byte)rand.Next(256), (byte)rand.Next(256), (byte)rand.Next(256));
        }
        static Random rand = new Random();
        #endregion

        #region Operators
#if LANG_JP
        /// <summary>
        /// CvColorからCvScalarに変換する暗黙のキャスト 
        /// </summary>
        /// <param name="self">新しい CvScalar の値を指定する CvColor</param>
        /// <returns>CvScalar</returns>
#else
        /// <summary>
        /// Creates a CvScalar with the members of the specified CvColor.
        /// </summary>
        /// <param name="self">A CvColor that specifies the coordinates for the new CvScalar.</param>
        /// <returns>CvScalar</returns>
#endif
	    public static implicit operator CvScalar(CvColor self)
	    {
		    return new CvScalar(self.B, self.G, self.R, 0);
	    }
#if LANG_JP
        /// <summary>
        /// CvScalarからCvColorに変換する暗黙のキャスト 
        /// </summary>
        /// <param name="obj">新しい CvColor の値を指定する CvScalar</param>
        /// <returns>CvColor</returns>
#else
        /// <summary>
        /// Creates a CvColor with the members of the specified CvScalar.
        /// </summary>
        /// <param name="obj">A CvScalar that specifies the coordinates for the new CvPoint.</param>
        /// <returns>CvColor</returns>
#endif
        public static implicit operator CvColor(CvScalar obj)
	    {
            return new CvColor((byte)obj.Val2, (byte)obj.Val1, (byte)obj.Val0);
	    }


#if LANG_JP
        /// <summary>
        /// == 演算子のオーバーロード
        /// </summary>
        /// <param name="lhs">左辺値</param>
        /// <param name="rhs">右辺値</param>
        /// <returns>等しければtrue</returns>
#else
        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the members of each CvPoint object are equal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are equal; otherwise, false.</returns>
#endif
	    public static bool operator==(CvColor lhs, CvColor rhs)
	    {
		    return lhs.Equals(rhs);
	    }
#if LANG_JP
        /// <summary>
        /// != 演算子のオーバーロード
        /// </summary>
        /// <param name="lhs">左辺値</param>
        /// <param name="rhs">右辺値</param>
        /// <returns>等しくなければtrue</returns>
#else
        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the members of each CvPoint object are unequal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are unequal; otherwise, false.</returns>
#endif
        public static bool operator !=(CvColor lhs, CvColor rhs)
        {
            return !lhs.Equals(rhs);
        }
#if LANG_JP
        /// <summary>
        /// 指定したオブジェクトと等しければtrueを返す 
        /// </summary>
        /// <param name="obj">比較するオブジェクト</param>
        /// <returns>型が同じで、メンバの値が等しければtrue</returns>
#else
        /// <summary>
        /// Specifies whether this object contains the same members as the specified Object.
        /// </summary>
        /// <param name="obj">The Object to test.</param>
        /// <returns>This method returns true if obj is the same type as this object and has the same members as this object.</returns>
#endif
        public bool Equals(CvColor obj)
	    {
            return (this.R == obj.R && this.G == obj.G && this.B == obj.B);
        }
        #endregion

        #region Overrided Methods
#if LANG_JP
        /// <summary>
        /// Equalsのオーバーライド
        /// </summary>
        /// <param name="obj">比較するオブジェクト</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Specifies whether this object contains the same members as the specified Object.
        /// </summary>
        /// <param name="obj">The Object to test.</param>
        /// <returns>This method returns true if obj is the same type as this object and has the same members as this object.</returns>
#endif   
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
#if LANG_JP
        /// <summary>
        /// GetHashCodeのオーバーライド
        /// </summary>
        /// <returns>このオブジェクトのハッシュ値を指定する整数値。</returns>
#else
        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this object.</returns>
#endif
        public override int GetHashCode()
        {
            return R.GetHashCode() + G.GetHashCode() + B.GetHashCode();
        }
#if LANG_JP
        /// <summary>
        /// 文字列形式を返す 
        /// </summary>
        /// <returns>文字列形式</returns>
#else
        /// <summary>
        /// Converts this object to a human readable string.
        /// </summary>
        /// <returns>A string that represents this object.</returns>
#endif
	    public override string ToString()
	    {
		    return string.Format("CvColor (r:{0} g:{1} b:{2})", R, G, B);
        }
        #endregion

        #region Existing color constants
#if LANG_JP
        /// <summary>
        /// 黒をあらわす色定数を取得する
        /// </summary>
#else
        /// <summary>
        /// Gets a system-defined color which represents black.
        /// </summary>
#endif
        static public CvColor Black { get { return new CvColor(0, 0, 0); } }
#if LANG_JP
        /// <summary>
        /// 白をあらわす色定数を取得する
        /// </summary>
#else
        /// <summary>
        /// Gets a system-defined color which represents white.
        /// </summary>
#endif
        static public CvColor White { get { return new CvColor(255, 255, 255); } }
#if LANG_JP
        /// <summary>
        /// グレーをあらわす色定数を取得する
        /// </summary>
#else
        /// <summary>
        /// Gets a system-defined color which represents gray.
        /// </summary>
#endif
        static public CvColor Gray { get { return new CvColor(128, 128, 128); } }
#if LANG_JP
        /// <summary>
        /// ピンクをあらわす色定数を取得する
        /// </summary>
#else
        /// <summary>
        /// Gets a system-defined color which represents pink.
        /// </summary>
#endif
        static public CvColor Pink { get { return new CvColor(255, 192, 203); } }
#if LANG_JP
        /// <summary>
        /// 赤をあらわす色定数を取得する
        /// </summary>
#else
        /// <summary>
        /// Gets a system-defined color which represents red.
        /// </summary>
#endif
        static public CvColor Red { get { return new CvColor(255, 0, 0); } }
#if LANG_JP
        /// <summary>
        /// マゼンタをあらわす色定数を取得する
        /// </summary>
#else
        /// <summary>
        /// Gets a system-defined color which represents magenta.
        /// </summary>
#endif
        static public CvColor Magenta { get { return new CvColor(255, 0, 255); } }
#if LANG_JP
        /// <summary>
        /// ライトグリーンをあらわす色定数を取得する
        /// </summary>
#else
        /// <summary>
        /// Gets a system-defined color which represents light green.
        /// </summary>
#endif
        static public CvColor LightGreen { get { return new CvColor(144, 238, 144); } }
#if LANG_JP
        /// <summary>
        /// 緑をあらわす色定数を取得する
        /// </summary>
#else
        /// <summary>
        /// Gets a system-defined color which represents green.
        /// </summary>
#endif
        static public CvColor Green { get { return new CvColor(0, 255, 0); } }
#if LANG_JP
        /// <summary>
        /// ダークグリーンをあらわす色定数を取得する
        /// </summary>
#else
        /// <summary>
        /// Gets a system-defined color which represents dark green.
        /// </summary>
#endif
        static public CvColor DarkGreen { get { return new CvColor(0, 100, 0); } }
#if LANG_JP
        /// <summary>
        /// シアンをあらわす色定数を取得する
        /// </summary>
#else
        /// <summary>
        /// Gets a system-defined color which represents cyan.
        /// </summary>
#endif
        static public CvColor Cyan { get { return new CvColor(0, 255, 255); } }
#if LANG_JP
        /// <summary>
        /// 蒼をあらわす色定数を取得する
        /// </summary>
#else
        /// <summary>
        /// Gets a system-defined color which represents blue.
        /// </summary>
#endif
        static public CvColor Blue { get { return new CvColor(0, 0, 255); } }
#if LANG_JP
        /// <summary>
        /// ネイビーをあらわす色定数を取得する
        /// </summary>
#else
        /// <summary>
        /// Gets a system-defined color which represents navy.
        /// </summary>
#endif
        static public CvColor Navy { get { return new CvColor(0, 0, 128); } }
#if LANG_JP
        /// <summary>
        /// 黄色をあらわす色定数を取得する
        /// </summary>
#else
        /// <summary>
        /// Gets a system-defined color which represents yellow.
        /// </summary>
#endif
        static public CvColor Yellow { get { return new CvColor(255, 217, 0); } }
#if LANG_JP
        /// <summary>
        /// オレンジをあらわす色定数を取得する
        /// </summary>
#else
        /// <summary>
        /// Gets a system-defined color which represents orange.
        /// </summary>
#endif
        static public CvColor Orange { get { return new CvColor(255, 165, 0); } }
#if LANG_JP
        /// <summary>
        /// 紫をあらわす色定数を取得する
        /// </summary>
#else
        /// <summary>
        /// Gets a system-defined color which represents violet.
        /// </summary>
#endif
        static public CvColor Violet { get { return new CvColor(238, 130, 238); } }
#if LANG_JP
        /// <summary>
        /// 茶色をあらわす色定数を取得する
        /// </summary>
#else
        /// <summary>
        /// Gets a system-defined color which represents brown.
        /// </summary>
#endif
        static public CvColor Brown { get { return new CvColor(165, 42, 42); } }
        #endregion
    }
}
