using System;
using System.Collections.Generic;
using AutoMapper;

namespace ConApp.Samples
{
    public class AutoMapperDemo
    {
        public AutoMapperDemo()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<Source, DtoSourceSameMember>();
                x.CreateMap<Source, DtoSourceDifferentMember>()
                    .ForMember(c => c.Description, q => { q.MapFrom(z => z.Content); });
            });
        }

        public class Source
        {
            public int Id { get; set; }
            public string Content { get; set; }
        }

        public class DtoSourceSameMember
        {
            public int Id { get; set; }
            public string Content { get; set; }
        }

        public class DtoSourceDifferentMember
        {
            public int Id { get; set; }
            public string Description { get; set; }
        }

        public static void AutoMapperDemo1_SameMember()
        {
            Source s = new Source { Id = 1, Content = "123" };

            DtoSourceSameMember dto = Mapper.Map<DtoSourceSameMember>(s);
            Console.WriteLine(dto.Id + "  " + dto.Content);

            List<Source> sList = new List<Source>
            {
                new Source{Id = 1,Content = "123456"},
                new Source{Id = 2,Content = "234567"},
                new Source{Id = 3,Content = "345678"},
            };
            List<DtoSourceSameMember> dtoList = Mapper.Map<List<DtoSourceSameMember>>(sList);
            foreach (DtoSourceSameMember item in dtoList)
            {
                Console.WriteLine(item.Id + "  " + item.Content);
            }
        }

        public static void AutoMapperDemo1_DifferentMember()
        {
            Source s = new Source { Id = 1, Content = "123" };

            DtoSourceDifferentMember dto = Mapper.Map<DtoSourceDifferentMember>(s);

            Console.WriteLine(dto.Id + "  " + dto.Description);

            List<Source> sList = new List<Source>
            {
                new Source{Id = 1,Content = "123456"},
                new Source{Id = 2,Content = "234567"},
                new Source{Id = 3,Content = "345678"},
            };
            List<DtoSourceDifferentMember> dtoList = Mapper.Map<List<DtoSourceDifferentMember>>(sList);
            foreach (DtoSourceDifferentMember item in dtoList)
            {
                Console.WriteLine(item.Id + "  " + item.Description);
            }
        }
    }
}