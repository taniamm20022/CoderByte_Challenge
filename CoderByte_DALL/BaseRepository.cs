using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderByte_DALL
{
    public class BaseRepository
    {
        private readonly DatabaseOptions _options;

        public BaseRepository(IOptions<DatabaseOptions> databaseOptions)
        {
            _options = databaseOptions.Value;
        }
    }
}
