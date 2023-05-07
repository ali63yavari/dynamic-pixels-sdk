using System;
using Newtonsoft.Json;

namespace models.dto
{
    public class Device
    {
          [JsonProperty("device_id")]
        public string DeviceId { get; set; } = null!;

        [JsonProperty("first_login")]
        public DateTime? FirstLogin { get; set; }
        [JsonProperty("last_login")]
        public DateTime? LastLogin { get; set; }
        [JsonProperty("package_name")]
        public string? PackageName { get; set; }
        [JsonProperty("sdk_version")]
        public string? SdkVersion { get; set; }
        [JsonProperty("version_name")]
        public string? VersionName { get; set; }
        [JsonProperty("version_code")]
        public string? VersionCode { get; set; }
        [JsonProperty("os_api_lavel")]
        public string? OsApiLevel { get; set; }
        [JsonProperty("device")]
        public string? _Device { get; set; }
        [JsonProperty("from")]
        public string? From { get; set; }
        [JsonProperty("model")]
        public string? Model { get; set; }
        [JsonProperty("product")]
        public string? Product { get; set; }
        [JsonProperty("carrier_name")]
        public string? CarrierName { get; set; }
        [JsonProperty("manufacturer")]
        public string? Manufacturer { get; set; }
        [JsonProperty("other_tags")]
        public string? OtherTags { get; set; }
        [JsonProperty("screen_width")]
        public string? ScreenWidth { get; set; }
        [JsonProperty("screen_height")]
        public string? ScreenHeight { get; set; }
        [JsonProperty("sdcard_state")]
        public string? SdcardState { get; set; }
        [JsonProperty("game_orientation")]
        public string? GameOrientation { get; set; }
        [JsonProperty("network_type")]
        public string? NetworkType { get; set; }
        [JsonProperty("mac_address")]
        public string? MacAddress { get; set; }
        [JsonProperty("ip_address")]
        public string? IpAddress { get; set; }
        [JsonProperty("device_name")]
        public string? DeviceName { get; set; }
        [JsonProperty("device_model")]
        public string? DeviceModel { get; set; }
        [JsonProperty("device_type")]
        public string? DeviceType { get; set; }
        [JsonProperty("operating_system")]
        public string? OperatingSystem { get; set; }
        [JsonProperty("processor_type")]
        public string? ProcessorType { get; set; }
        [JsonProperty("processor_count")]
        public string? ProcessorCount { get; set; }
        [JsonProperty("processor_frequency")]
        public string? ProcessorFrequency { get; set; }
        [JsonProperty("graphic_device_name")]
        public string? GraphicsDeviceName { get; set; }
        [JsonProperty("graphic_device_vendor")]
        public string? GraphicsDeviceVendor { get; set; }
        [JsonProperty("graphic_memory_size")]
        public string? GraphicsMemorySize { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}