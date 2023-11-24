using AutoMapper;
using MediatR;
using QSMS.Application.Features.DTOs.Tag;
using QSMS.Application.Repositories.Abstract.Product;
using QSMS.Application.Repositories.Abstract.ProductImage;
using QSMS.Application.Repositories.Abstract.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Application.Features.Commands.Tag.CreateTag
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommandRequest, CreateTagDto>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        public CreateTagCommandHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }
        public async Task<CreateTagDto> Handle(CreateTagCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Tag mappedTag = _mapper.Map<Domain.Entities.Tag>(request);
            var res = await _tagRepository.AddAsync(mappedTag);
            if (!res)
            {
                throw new Exception("Eklemede Hata!!!");
            }
            await _tagRepository.SaveAsync();
            return new();
        }
    }
}
