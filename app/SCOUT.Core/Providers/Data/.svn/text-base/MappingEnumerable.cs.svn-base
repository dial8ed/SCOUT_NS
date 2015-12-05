using System.Collections;
using System.Collections.Generic;

namespace SCOUT.Core.Data
{
    public class MappingEnumerable<Input,Output> : IMappingEnumerable<Input,Output>
    {
        private IMapper<Input, Output> mapper;
        private IEnumerable<Input> inputItems;

        public MappingEnumerable(IMapper<Input,Output> mapper, IEnumerable<Input> inputItems)
        {
            this.mapper = mapper;
            this.inputItems = inputItems;
        }

        public IEnumerable<Output> MapAllFrom(IEnumerable<Input> input)
        {
            foreach (Input item in input)
            {
                yield return mapper.MapFrom(item);
            }            
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable<Output>)this).GetEnumerator();
        }
    }
}