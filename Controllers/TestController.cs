using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using testapisecond.Entity;
using System.Linq;
using testapisecond.Repo;
using Newtonsoft.Json;



namespace testapisecond.Controllers
{
    [ApiController]
    [Route("api/testcontroler")]
    public class TestController:ControllerBase
    {
        private readonly IRepo _repo;  
        private readonly ILogger<TestController> _logger;      
        public TestController(IRepo repo,ILogger<TestController> logger)
        {
           _repo = repo;
           _logger = logger;
           _logger.Log(LogLevel.Information,"Hello Logger is Running");
           _logger.LogInformation("Helloo from loginfo");
           _logger.LogWarning("Test Warining");   
           _logger.LogTrace("trace meassage"); 

              try
           {
               throw new Exception("Try error");
           }

           catch(Exception e)
           {

               _logger.LogError(e, "Catch error");
           }     
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<EntityModel>> Get ()
        {
           
            var entities = _repo.Get();
             _logger.LogInformation(1001,"Getting All the Details of {name} students",entities.Count( p => p.Id > 0));
            
            using(_logger.BeginScope(new Dictionary<string,object>{  {"MethodName","GetAll"}}  ))
            {

                _logger.LogInformation("from Get Mehthod");


            }

            return Ok(entities);
            
        }



        
        [HttpGet("{id}")]
        public ActionResult<EntityModel> GetById ([FromRoute]int id)
        {
            var entities = _repo.GetById(id);
            if (entities is null)
            {
                return NotFound();
            }
            _logger.LogInformation(1001,"Getting the Details of Student {name}",entities.Name);
            return Ok(entities);
            
        }

        [HttpPost]
        [Route("json")]
        public void Json([FromBody]EntityModel str)
        {
           string json = JsonConvert.SerializeObject(str, Formatting.Indented);

            try
            {
                    EntityModel jperson= JsonConvert.DeserializeObject<EntityModel> (json);
                    Console.WriteLine("Name is "+jperson.Name);

            }

            catch(Exception ex){
                Console.WriteLine(ex);
            }
                      
        }
        
        [HttpPost]
        public ActionResult<EntityModel> Create (EntityModel model)
        {
            _repo.Create(model);
            _logger.LogInformation(1002,"Creating New Student {name}",model.Name);

            return CreatedAtAction(nameof(GetById),new {id = model.Id},model);
            
        }

        [HttpPut("{id}")]
        public ActionResult<EntityModel> Update ([FromRoute]int id,[FromBody]EntityModel model)
        {
            var entities = _repo.GetById(id);
            if (entities is null)
            {
                return NotFound();
            }

            EntityModel model1 = new EntityModel() 
            {
                Id= id,
                Name = model.Name,
                Email= model.Email,
                DateTime = DateTimeOffset.UtcNow
            }; 
            
            _repo.Update(model1);
            _logger.LogInformation(1003,"Updated New Student {name}",model1.Name);
            _logger.LogInformation(1001,"Getting the Details of Updated Student {name}",_repo.GetById(model1.Id).Name);

            return Ok(_repo.Get());
            
        }

         [HttpDelete("{id}")]
        public ActionResult<EntityModel> Delete ([FromRoute]int id)
        {
            var entities = _repo.GetById(id);
            if (entities is null)
            {
                return NotFound();
            }
            _logger.LogInformation(1004,"Deleting New Student {name}",entities.Name);

            _repo.Delete(entities);
            _logger.LogInformation(1001,"Getting All the Details of {name} students",_repo.Get().Count( p => p.Id > 0));

            return Ok(_repo.Get());
            
        }


    }
}