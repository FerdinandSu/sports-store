import yaml
import uuid
import os

with open('targets.yaml','r',encoding='utf-8') as f:
    config = yaml.safe_load(f)

repo = config['repo']
dockerhub_id = config['id']
debug_docker_network = config['network']
targets = config['targets']

template_base_dir = 'template'
template_prop_dir = os.path.join(template_base_dir, 'Properties')
template_pub_dir = os.path.join(template_prop_dir, 'PublishProfiles')


for target in targets:
    proj_id = str(uuid.uuid1())
    upper_proj_id = proj_id.upper()
    proj_name = target['Name']
    macros = {
        '@@proj_id@@': proj_id,
        '@@dockerhub_id@@': dockerhub_id,
        '@@docker_repo@@': repo,
        '@@debug_docker_network@@': debug_docker_network,
        '@@proj_name@@': proj_name
    }
    base_dir = os.path.join('src', proj_name)
    prop_dir = os.path.join(base_dir, 'Properties')
    pub_dir = os.path.join(prop_dir, 'PublishProfiles')
    main_file = os.path.join(base_dir, 'Program.cs')
    mapping = {
        os.path.join(template_pub_dir, 'http___192.168.1.102_5000_.pubxml'): os.path.join(pub_dir, 'http___192.168.1.102_5000_.pubxml'),
        os.path.join(template_prop_dir, 'launchSettings.json'): os.path.join(prop_dir, 'launchSettings.json'),
        os.path.join(template_base_dir, 'any.csproj'): os.path.join(base_dir, f'{proj_name}.csproj'),
        os.path.join(template_base_dir, 'appsettings.json'): os.path.join(base_dir, 'appsettings.json'),
        os.path.join(template_base_dir, 'Dockerfile'): os.path.join(base_dir, 'Dockerfile'),
        os.path.join(template_base_dir, 'MResponse.cs'): os.path.join(base_dir, 'MResponse.cs'),
        os.path.join(template_base_dir, 'Program.cs'): main_file,

    }
    # mkdir && base
    os.mkdir(base_dir)
    os.mkdir(prop_dir)
    os.mkdir(pub_dir)
    print(f'Project("{{9A19103F-16F7-4668-BE54-9A1E7A4F7556}}") = "{proj_name}", "src\{proj_name}\{proj_name}.csproj", "{{{upper_proj_id}}}"')
    print('EndProject')
    # file_mapping
    for (src, dst) in mapping.items():
        f_in = open(src, 'r', encoding='utf-8')
        f_out = open(dst, 'w', encoding='utf-8')
        for line in f_in:
            for (m_in, m_out) in macros.items():
                line = line.replace(m_in, m_out)
            f_out.write(line)
        f_in.close()
        if dst == main_file:
            for api in target['Apis']:
                api_name=api['Name']
                ret_value=[]
                for output in api['Output']:
                    out_name=output['Name']
                    ret_value.append(f'{{"{out_name}",""}}')
                ret_value_ser=','.join(ret_value)
                f_out.write(f'app.MapPost("/{api_name}", (Dictionary<string,string> arg) =>  new Dictionary<string,string>{{{ret_value_ser}}});\n')
            f_out.write(f'app.Run();\n')
        f_out.close()
