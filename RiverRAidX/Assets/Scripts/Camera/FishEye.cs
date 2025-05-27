using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FishEyeFeature : ScriptableRendererFeature
{
    [System.Serializable]
    public class FishEyeSettings
    {
        public RenderPassEvent renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
        public Material material;
        [Range(0, 1)] public float strength = 0.5f;
    }

    public FishEyeSettings settings = new FishEyeSettings();
    FishEyePass _pass;

    public override void Create()
    {
        _pass = new FishEyePass(settings.material, settings.strength);
        _pass.renderPassEvent = settings.renderPassEvent;
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if (settings.material == null)
            return;
        _pass.Setup(renderer.cameraColorTargetHandle);
        renderer.EnqueuePass(_pass);
    }

    class FishEyePass : ScriptableRenderPass
    {
        private Material _material;
        private float _strength;
        private RTHandle _source;

        public FishEyePass(Material material, float strength)
        {
            _material = material;
            _strength = strength;
        }

        public void Setup(RTHandle source)
        {
            _source = source;
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            CommandBuffer cmd = CommandBufferPool.Get("FishEyeEffect");

            _material.SetFloat("_Strength", _strength);

            Blit(cmd, _source, _source, _material);
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }
}