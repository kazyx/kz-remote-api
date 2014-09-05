
namespace Kazyx.RemoteApi.Camera
{
    /// <summary>
    /// EV parameter conversion utility.
    /// </summary>
    public class EvConverter
    {
        private EvConverter() { }

        /// <summary>
        /// Convert step definition from integer value to the Enum value.
        /// </summary>
        /// <param name="definition"></param>
        /// <returns>Ev step definition in enum.</returns>
        public static EvStepDefinition GetDefinition(int definition)
        {
            switch (definition)
            {
                case 1:
                    return EvStepDefinition.EV_1_3;
                case 2:
                    return EvStepDefinition.EV_1_2;
                default:
                    return EvStepDefinition.Undefined;
            }
        }

        /// <summary>
        /// Convert step definition from Enum value to integer value.
        /// </summary>
        /// <param name="definition"></param>
        /// <returns>Ev step definition in integer.</returns>
        public static int GetIntDefinition(EvStepDefinition definition)
        {
            switch (definition)
            {
                case EvStepDefinition.EV_1_3:
                    return 1;
                case EvStepDefinition.EV_1_2:
                    return 2;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">Index of the EV for current step definition</param>
        /// <param name="definition">Current step definition</param>
        /// <returns>Exposure value to display.</returns>
        public static float GetEv(int index, int definition)
        {
            return GetEv(index, GetDefinition(definition));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">Index of the EV for current step definition</param>
        /// <param name="definition">Current step definition</param>
        /// <returns>Exposure value to display</returns>
        public static float GetEv(int index, EvStepDefinition definition)
        {
            float by = 0;
            switch (definition)
            {
                case EvStepDefinition.EV_1_3:
                    by = 0.33f;
                    break;
                case EvStepDefinition.EV_1_2:
                    by = 0.5f;
                    break;
                default:
                    return 0;
            }

            return (float)index * by;
        }
    }

    /// <summary>
    /// Ev incrementation step definitions.
    /// </summary>
    public enum EvStepDefinition
    {
        /// <summary>
        /// Undefined step definition.
        /// </summary>
        Undefined,
        /// <summary>
        /// Increament of the index represents that EV is increased by 0.33.
        /// </summary>
        EV_1_3,
        /// <summary>
        /// Increament of the index represents that EV is increased by 0.5.
        /// </summary>
        EV_1_2
    }
}
