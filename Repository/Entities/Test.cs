using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drm.Repository.Entities
{
  public class Test
  {
    public int Id { get; set; }
    public string Text1 { get; set; }
    public string Text2 { get; set; }
  }
}
