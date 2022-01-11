using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generators
{
    public abstract class AbstractGenericGenerator : AbstractGenerator
    {
        protected int Size;

        public AbstractGenerator GenericGenerator;

        public abstract override object Generate();
    }
}
