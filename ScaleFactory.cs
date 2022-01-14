using System.Collections.Generic;

namespace ScaleFactory
{
    /// <summary>
    /// 音階クラス
    /// </summary>
    public struct Scale
    {
        /// <summary>
        /// 音階
        /// </summary>
        private ushort InternalValue { get; set; }

        public static readonly ushort C  =  0;
        public static readonly ushort Cs =  1;
        public static readonly ushort D  =  2;
        public static readonly ushort Ds =  3;
        public static readonly ushort E  =  4;
        public static readonly ushort F  =  5;
        public static readonly ushort Fs =  6;
        public static readonly ushort G  =  7;
        public static readonly ushort Gs =  8;
        public static readonly ushort A  =  9;
        public static readonly ushort As = 10;
        public static readonly ushort B  = 11;

        /// <summary>
        /// 音階数
        /// </summary>
        private static readonly ushort Count = 12;

        /// <summary>
        /// ToString用リスト
        /// </summary>
        private static readonly List<string> ScaleString = new List<string>{ "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };

        /// <summary>
        /// ushortからScaleへのキャスト
        /// </summary>
        /// <param name="scale">変換前</param>
        public static implicit operator Scale(ushort scale)
        {
            return new Scale
            {
                InternalValue = scale
            };
        }

        /// <summary>
        /// Scaleからushortへのキャスト
        /// </summary>
        /// <param name="scale">変換前</param>
        public static explicit operator ushort(Scale scale)
        {
            return scale.InternalValue;
        }

        /// <summary>
        /// 二項加算演算子のオーバーロード
        /// </summary>
        /// <param name="s1">左オペランド</param>
        /// <param name="s2">右オペランド</param>
        /// <returns>足された音階</returns>
        public static Scale operator +(Scale s1, Scale s2)
        {
            return (Scale)(((ushort)s1 + (ushort)s2) % Count);
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ScaleString[InternalValue];
        }
    }

    /// <summary>
    /// コードのEnum
    /// </summary>
    public enum Code : ushort
    {
        Major = 0,
        Minor
    }

    /// <summary>
    /// スケール作るクラス
    /// </summary>
    class ScaleFactory
    {
        private static readonly List<Scale> CMAJOR = new List<Scale> { Scale.C, Scale.D, Scale.E, Scale.F, Scale.G, Scale.A, Scale.B };
        private static readonly List<Scale> CMINOR = new List<Scale> { Scale.C, Scale.D, Scale.Ds, Scale.F, Scale.G, Scale.Gs, Scale.B };
        private static readonly List<List<Scale>> CSCALE = new List<List<Scale>> { CMAJOR, CMINOR };

        /// <summary>
        /// スケール作るメソッド
        /// </summary>
        /// <param name="root"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static List<Scale> MakeScales(Scale root, Code code)
        {
            // Cのスケールを取得する
            List<Scale> scales = new List<Scale>(CSCALE[(ushort)code]);

            // 全音階にroot分加算する
            for(int i = 0; i < scales.Count; i++)
            {
                scales[i] += root;
            }
               
            // スケールを返す
            return scales;
        }
    }

}
