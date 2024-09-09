export default function SubmitButton({ text }) {
  return (
    <button className="w-full mt-6 bg-blue-500 text-white py-2 px-4 rounded-lg hover:bg-blue-600 transition-colors">
      {text}
    </button>
  );
}
