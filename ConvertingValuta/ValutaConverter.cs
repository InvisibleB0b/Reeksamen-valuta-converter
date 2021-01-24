using System;

namespace ConvertingValuta
{
    public static class ValutaConverter
    {
        public static double TilSvenske(double danskeKroner)
        {
            return danskeKroner / 0.7041;
        }

        public static double TilDanske(double svenskeKroner)
        {
            return svenskeKroner * 0.7041;
        }
    }
}
