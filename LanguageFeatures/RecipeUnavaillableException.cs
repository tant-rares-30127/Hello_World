using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures
{
    [Serializable]
    public class RecipeUnavaillableException : Exception
    {
        public RecipeUnavaillableException() { }
        public RecipeUnavaillableException(string message) : base(message) { }
        public RecipeUnavaillableException(string message, Exception inner) : base(message, inner) { }
        protected RecipeUnavaillableException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
