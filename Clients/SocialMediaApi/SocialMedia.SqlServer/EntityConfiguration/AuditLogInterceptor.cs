using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SocialMedia.SqlServer.EntityConfiguration
{
    public class AuditLogInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var auditLogs = eventData.Context.ChangeTracker.Entries()
                                                            .Where(i => i.Entity is not AuditLog)
                                                            .Where
                                                            (
                                                                i => i.State == EntityState.Added ||
                                                                i.State == EntityState.Modified ||
                                                                i.State == EntityState.Deleted
                                                            );

            var auditLogEntities = new List<AuditLog>();
            foreach (var item in auditLogs) 
            {
                var log = new AuditLog
                {
                    TableName = item.Metadata.GetTableName(),
                    Operation = item.State.ToString(),
                    CreatedDate = DateTime.UtcNow,
                };

                if (item.State == EntityState.Modified) 
                {
                    log.OldValue = JsonSerializer.Serialize(item.OriginalValues.Properties.ToDictionary(x => x.Name, x => item.OriginalValues[x]));
                    log.NewValue = JsonSerializer.Serialize(item.CurrentValues.Properties.ToDictionary(x => x.Name, x => item.CurrentValues[x]));
                }

                else if(item.State == EntityState.Added)
                {
                    log.NewValue = JsonSerializer.Serialize(item.CurrentValues.Properties.ToDictionary(x=>x.Name, x=>item.CurrentValues));
                }

                else if (item.State == EntityState.Deleted)
                {
                    log.OldValue = JsonSerializer.Serialize(item.OriginalValues.Properties.ToDictionary(x => x.Name, x => item.OriginalValues[x]));
                }

                auditLogEntities.Add(log);

            }

            eventData.Context.Set<AuditLog>().AddRange(auditLogEntities);


            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
