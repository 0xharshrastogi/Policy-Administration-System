const { fetch: orignalFetch } = window;

class Interceptor {}

async function customFetch(...args: any[]): Promise<Response> {
  console.count('Fetch Calls');
  const [resource, config] = args;
  return orignalFetch(resource, config);
}

window.fetch = customFetch;
