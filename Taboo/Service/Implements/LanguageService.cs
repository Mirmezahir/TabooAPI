using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taboo.DAL;
using Taboo.DTOs;
using Taboo.Entities;
using Taboo.Service.Abstracts;

namespace Taboo.Service.Implements
{
    public class LanguageService(TaboDbContex _context) : ILAnguageService
    {
        async Task ILAnguageService.CreateAsync(LanguageCreateDto dto)
        {
            await _context.Languages.AddAsync(new Language
            {
                Code = dto.Code,
                Name = dto.Name,
                Icon = dto.Icon,  
            }) ;
           await _context.SaveChangesAsync();
        }

        async Task<Boolean> ILAnguageService.DeleteAsync(LanguageDeleteDto dto)
        {
            Boolean result = false;
            var data = await _context.Languages.FirstOrDefaultAsync(x => x.Code == dto.Code);
            if (data != null)
            {
               _context.Languages.Remove(data);
               await _context.SaveChangesAsync();
               result = true;   
               return result;
            }
            return result;  
           
        }

        async  Task<IEnumerable<LanguageGetDto>> ILAnguageService.GetAsync()
        {
            return await _context.Languages.Select(x=> new LanguageGetDto
            {
                Code= x.Code,
                Name= x.Name,
                Icon= x.Icon,


            }).ToListAsync();
            
        }

       async Task<Boolean> ILAnguageService.UpdateAsync(LanguageUpdateDto dto)
        {
           Boolean result = false;
            var data =await _context.Languages.FirstOrDefaultAsync(x=> x.Code == dto.Code);
            if (data != null)
            {
                data.Code = dto.Code;   
                data.Name = dto.Name;
                data.Icon = dto.Icon;
               await _context.SaveChangesAsync();
                result = true; return result;
            }
            return result;

        }
    }
}
