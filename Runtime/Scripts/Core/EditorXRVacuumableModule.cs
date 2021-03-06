using System.Collections.Generic;
using Unity.EditorXR.Interfaces;
using Unity.EditorXR.Modules;
using Unity.XRTools.ModuleLoader;

namespace Unity.EditorXR.Core
{
    class EditorXRVacuumableModule : IModuleDependency<WorkspaceModule>
    {
        readonly List<IVacuumable> m_Vacuumables = new List<IVacuumable>();

        public List<IVacuumable> vacuumables { get { return m_Vacuumables; } }

        void OnWorkspaceCreated(IWorkspace workspace)
        {
            m_Vacuumables.Add(workspace);
        }

        void OnWorkspaceDestroyed(IWorkspace workspace)
        {
            m_Vacuumables.Remove(workspace);
        }

        public void ConnectDependency(WorkspaceModule dependency)
        {
            dependency.workspaceCreated += OnWorkspaceCreated;
            dependency.workspaceDestroyed += OnWorkspaceDestroyed;
        }

        public void LoadModule() { }

        public void UnloadModule() { }
    }
}
