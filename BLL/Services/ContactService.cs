using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL.Repos;
using System.Collections.Generic;

public class ContactService
{
    public static List<ContactDTO> GetAll()
    {
        var repo = new ContactRepo();
        var data = repo.GetAll();
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Contact, ContactDTO>());
        var mapper = new Mapper(config);
        return mapper.Map<List<ContactDTO>>(data);
    }

    public static ContactDTO GetById(int id)
    {
        var repo = new ContactRepo();
        var data = repo.GetById(id); 
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Contact, ContactDTO>());
        var mapper = new Mapper(config);
        return mapper.Map<ContactDTO>(data);
    }

    public static List<ContactDTO> Get(string name)
    {
        var repo = new ContactRepo();
        var data = repo.GetByName(name);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Contact, ContactDTO>());
        var mapper = new Mapper(config);
        return mapper.Map<List<ContactDTO>>(data);
    }

    public static void Create(ContactDTO c)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<ContactDTO, Contact>());
        var mapper = new Mapper(config);
        var contact = mapper.Map<Contact>(c);
        var repo = new ContactRepo();
        repo.Create(contact);
    }

    public static void Update(ContactDTO c)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<ContactDTO, Contact>());
        var mapper = new Mapper(config);
        var contact = mapper.Map<Contact>(c);
        var repo = new ContactRepo();
        repo.Update(contact);
    }

    public static void Delete(int id)
    {
        var repo = new ContactRepo();
        repo.Delete(id);
    }

    public static List<ContactDTO> GetByCategory(string category)
    {
        var repo = new ContactRepo();
        var data = repo.GetByCategory(category); 
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Contact, ContactDTO>());
        var mapper = new Mapper(config);
        return mapper.Map<List<ContactDTO>>(data);
    }

}
