using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extras
{
    public static class MathUtils
    {
        /// <summary>
        /// meter per second to kilometer per hour
        /// </summary>
        /// <param name="valueInms"></param>
        /// <returns></returns>
        public static float msTokmh(float valueInms) => valueInms * 3.6f;

    }
}
