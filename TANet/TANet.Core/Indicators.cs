﻿using System.Collections.Generic;
using System.Linq;
using TANet.Contracts.Enums;
using TANet.Contracts.Models;
using TANet.Contracts.OperationResults.Indicators;

namespace TANet.Core
{
    public static class Indicators
    {
        #region ExtendedMacd
                      
        public static ExtendedMacdResult ExtendedMacd(decimal[] input, int fastPeriod, int slowPeriod, int signalPeriod)
        {
            return Indicators.ExtendedMacd(input, MovingAverageType.Ema, fastPeriod, MovingAverageType.Ema, slowPeriod, MovingAverageType.Ema, signalPeriod);
        }
        public static ExtendedMacdResult ExtendedMacd(decimal[] input, int fastPeriod, int slowPeriod, int signalPeriod, MacdSignalType signalType)
        {
            return Indicators.ExtendedMacd(input, MovingAverageType.Ema, fastPeriod, MovingAverageType.Ema, slowPeriod, MovingAverageType.Ema, signalPeriod, signalType: signalType);
        }
        public static ExtendedMacdResult ExtendedMacd(List<Candle> input, int fastPeriod, int slowPeriod, int signalPeriod)
        {
            return Indicators.ExtendedMacd(input, MovingAverageType.Ema, fastPeriod, MovingAverageType.Ema, slowPeriod, MovingAverageType.Ema, signalPeriod);
        }
        public static ExtendedMacdResult ExtendedMacd(List<Candle> input, int fastPeriod, int slowPeriod, int signalPeriod, MacdSignalType signalType)
        {
            return Indicators.ExtendedMacd(input, MovingAverageType.Ema, fastPeriod, MovingAverageType.Ema, slowPeriod, MovingAverageType.Ema, signalPeriod, signalType: signalType);
        }
        public static ExtendedMacdResult ExtendedMacd(List<Candle> input, int fastPeriod, int slowPeriod, int signalPeriod, IndicatorCalculationBase calculationBase)
        {
            return Indicators.ExtendedMacd(input, MovingAverageType.Ema, fastPeriod, MovingAverageType.Ema, slowPeriod, MovingAverageType.Ema, signalPeriod, calculationBase: calculationBase);
        }
        public static ExtendedMacdResult ExtendedMacd(List<Candle> input, int fastPeriod, int slowPeriod, int signalPeriod, MacdSignalType signalType, IndicatorCalculationBase calculationBase)
        {
            return Indicators.ExtendedMacd(input, MovingAverageType.Ema, fastPeriod, MovingAverageType.Ema, slowPeriod, MovingAverageType.Ema, signalPeriod, signalType: signalType, calculationBase: calculationBase);
        }

        #endregion

        #region WMA

        public static MovingAverageResult Wma(decimal[] input, int period)
        {
            return Indicators.MovingAverage(input, MovingAverageType.Wma, period);
        }
        public static MovingAverageResult Wma(List<Candle> input, int period)
        {
            return Indicators.MovingAverage(input, MovingAverageType.Wma, period);
        }
        public static MovingAverageResult Wma(List<Candle> input, int period, IndicatorCalculationBase calculationBase)
        {
            return Indicators.MovingAverage(input, MovingAverageType.Wma, period, calculationBase: calculationBase);
        }

        #endregion

        public static ExtendedMacdResult ExtendedMacd(List<Candle> candles, MovingAverageType fastMaType, int fastPeriod, MovingAverageType slowMaType, int slowPeriod, MovingAverageType signalMaType, int signalPeriod, IndicatorCalculationBase calculationBase = IndicatorCalculationBase.Close, MacdSignalType signalType = MacdSignalType.ZeroLineCrossover)
        {
            decimal[] input;
            if (calculationBase == IndicatorCalculationBase.Close)
                input = candles.Select(c => c.Close).ToArray();

            else if (calculationBase == IndicatorCalculationBase.Open)
                input = candles.Select(c => c.Open).ToArray();

            else if (calculationBase == IndicatorCalculationBase.High)
                input = candles.Select(c => c.High).ToArray();

            else if (calculationBase == IndicatorCalculationBase.Low)
                input = candles.Select(c => c.Low).ToArray();

            else if (calculationBase == IndicatorCalculationBase.Volume)
                input = candles.Select(c => c.Volume).ToArray();

            else
                input = candles.Select(c => c.Close).ToArray();

            return ExtendedMacd(input, fastMaType, fastPeriod, slowMaType, slowPeriod, signalMaType, signalPeriod);
        }
        public static ExtendedMacdResult ExtendedMacd(decimal[] input, MovingAverageType fastMaType, int fastPeriod, MovingAverageType slowMaType, int slowPeriod, MovingAverageType signalMaType, int signalPeriod, MacdSignalType signalType = MacdSignalType.ZeroLineCrossover)
        {
            return TANet.Util.StaticClasses.Indicators.MacdExt(input, fastMaType, fastPeriod, slowMaType, slowPeriod, signalMaType, signalPeriod, signalType);
        }

        public static MovingAverageResult MovingAverage(List<Candle> candles, MovingAverageType maType, int period, IndicatorCalculationBase calculationBase = IndicatorCalculationBase.Close)
        {
            decimal[] input;
            if (calculationBase == IndicatorCalculationBase.Close)
                input = candles.Select(c => c.Close).ToArray();

            else if (calculationBase == IndicatorCalculationBase.Open)
                input = candles.Select(c => c.Open).ToArray();

            else if (calculationBase == IndicatorCalculationBase.High)
                input = candles.Select(c => c.High).ToArray();

            else if (calculationBase == IndicatorCalculationBase.Low)
                input = candles.Select(c => c.Low).ToArray();

            else if (calculationBase == IndicatorCalculationBase.Volume)
                input = candles.Select(c => c.Volume).ToArray();

            else
                input = candles.Select(c => c.Close).ToArray();

            return MovingAverage(input, maType, period);
        }
        public static MovingAverageResult MovingAverage(decimal[] input, MovingAverageType maType, int period)
        {
            return TANet.Util.StaticClasses.Indicators.Ma(input, maType, period);
        }
    }
}