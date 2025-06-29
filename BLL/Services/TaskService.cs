using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL.Repos;
using System.Collections.Generic;

public class TaskService
{
    public static List<TaskDTO> GetAll()
    {
        var repo = new TaskRepo();
        var data = repo.GetAll();
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Task, TaskDTO>());
        var mapper = new Mapper(config);
        return mapper.Map<List<TaskDTO>>(data);
    }

    public static TaskDTO GetById(int id)
    {
        var repo = new TaskRepo();
        var data = repo.GetById(id); 
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Task, TaskDTO>());
        var mapper = new Mapper(config);
        return mapper.Map<TaskDTO>(data);
    }

    

    public static void Create(TaskDTO c)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, Task>());
        var mapper = new Mapper(config);
        var Task = mapper.Map<Task>(c);
        var repo = new TaskRepo();
        repo.Create(Task);
    }

}
