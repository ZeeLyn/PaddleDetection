using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices;
using FreeRedis;

namespace API.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public static int Id { get; set; }
        private RedisClient RedisClient { get; }

        public TaskController(RedisClient redisClient)
        {
            RedisClient = redisClient;
        }

        [HttpGet("run")]
        public async Task<IActionResult> Run()
        {
            var psi = new ProcessStartInfo("pipeline.exe",
                "--config E:\\GitHub\\PaddleDetection\\API\\bin\\Debug\\net7.0\\infer_cfg_pphuman.yml -o MOT.enable=True --video_file=E:\\GitHub\\PaddleDetection\\demo_input\\test_720p.mp4 --device=gpu --output_dir=E:\\GitHub\\PaddleDetection\\API\\demo_output --do_entrance_counting");

            var process = new Process();
            process.StartInfo = psi;
            process.Start();
            Id = process.Id;

            return Ok(new
            {
                process.Id,
                process.SessionId
            });
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);

        [HttpGet("quit")]
        public async Task<IActionResult> Quit()
        {
            var p = Process.GetProcessById(Id);
            p.Kill(true);
            //TerminateProcess(p.Handle, 1);
            return Ok();
        }


        [HttpPost("heart_beat")]
        public async Task<IActionResult> HeartBeat([FromBody] TaskHartBeat task)
        {
            await RedisClient.SetAsync($"task_heart_beat:{task.TaskId}", DateTime.Now, 20);
            return Ok();
        }
    }
}